using System;
using System.Drawing;
using System.Windows.Forms;
using TwinCAT.Ads;
using TwinCAT.TypeSystem;
using TCEVENTLOGGERLib;


namespace Beckhoff_VS_Visualisation
{
    public partial class main : Form
    {
        //AmsPort ADS_Port = 851;
        //AmsNetId AMS_NetID;
        DateTime dt;
        /*LIST OF PLC VARIABLE USED IN PROJECT*/
        IValueSymbol prgAlarms_test;
        IValueSymbol bResetCnts;
        IValueSymbol AlarmsCtrl_bAckAllBtn;
        int errorCnt = 0;
        public main()
        {
            InitializeComponent();
            CheckConnectionWithLocalPLC();
        }
        private TcAdsClient ads = new TcAdsClient();
        TcEventLog tcEventLogger = new TcEventLog();
        
        int langId = 1033;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                prgAlarms_test  = GetAdsVariable("prgAlarms.test");
                bResetCnts = GetAdsVariable(".bResetCnts");
                AlarmsCtrl_bAckAllBtn = GetAdsVariable("AlarmsCtrl.bAckAllBtn");
            }
            catch(Exception error2)
            {
                master myMaster = new master();
                errorCnt++;
               myMaster.ErrorsCounterDisplay = errorCnt.ToString();
            }

            eventView1.View = View.Details;
            eventView1.Columns.Add("Time", "Time");
            eventView1.Columns.Add("Type", "Type");
            eventView1.Columns.Add("Source", "Source");
            eventView1.Columns.Add("Message", "Message");

            foreach (TcEvent evt in tcEventLogger.EnumLoggedEventsEx())
                AddEvent(evt);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dt = DateTime.Now;
            try
            {
                textBox1.Text = GetAdsVariableValueString<Int32>("prgAlarms.HMI_Alarms_Counter");
                label2.Text = dt.ToString();
                label4.Text = GetAdsVariableValueString<int>(".stDeviceCtrl.iBPM"); 

                statisticViewier2.Label_4 = GetAdsVariableValueString<UInt32>(".udiTriggersCnt_1");
                statisticViewier2.Label_5 = GetAdsVariableValueString<UInt32>(".udiRejectsCnt1");
                statisticViewier2.Label_6 = GetAdsVariableValueString<Single>(".rEff1");

                statisticViewier3.Label_4 = GetAdsVariableValueString<UInt32>(".udiTriggersCnt_2");
                statisticViewier3.Label_5 = GetAdsVariableValueString<UInt32>(".udiRejectsCnt2");
                statisticViewier3.Label_6 = GetAdsVariableValueString<Single>(".rEff2");

                statisticViewier4.Label_4 = GetAdsVariableValueString<UInt32>(".udiTriggersCnt_3");
                statisticViewier4.Label_5 = GetAdsVariableValueString<UInt32>(".udiRejectsCnt3");
                statisticViewier4.Label_6 = GetAdsVariableValueString<Single>(".rEff3");

                statisticViewier5.Label_4 = GetAdsVariableValueString<UInt32>(".udiTriggersCnt_4");
                statisticViewier5.Label_5 = GetAdsVariableValueString<UInt32>(".udiRejectsCnt4");
                statisticViewier5.Label_6 = GetAdsVariableValueString<Single>(".rEff4");

                statisticViewier1.Label_4 = GetAdsVariableValueString<UInt32>(".udiInfeedCnt");
                statisticViewier1.Label_5 = GetAdsVariableValueString<UInt32>(".udiRejectsCnt");
                statisticViewier1.Label_6 = GetAdsVariableValueString<Single>(".rEff7");
            }
            catch (Exception error1)
            {
                errorCnt++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            prgAlarms_test.WriteValue(true);

            if ((bool)prgAlarms_test.ReadValue())
            {
                button1.BackColor = Color.Green;
                button2.BackColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prgAlarms_test.WriteValue(false);

            if (!(bool)prgAlarms_test.ReadValue())
            {
                button2.BackColor = Color.Green;
                button1.BackColor = Color.Red;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = "Reset\n" + dt.ToString();
            bResetCnts.WriteValue(true);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /********************FUNCTIONS*************************************/
        public bool CheckConnectionWithLocalPLC()
        {
            try
            {
                ads.Connect(AmsNetId.Local, 851);
                return (ads.IsConnected);
            }
            catch (Exception error)
            {
                timer1.Enabled = false;
                return (ads.IsConnected);
                MessageBox.Show(error.Message.ToString());
            }
        }
        public string GetAdsVariableValueString<T>(string name)
        {
            return ((T)ads.ReadAny(ads.CreateVariableHandle(name), typeof(T))).ToString();
        }

        public IValueSymbol GetAdsVariable(string name)
        {
            ISymbolLoader symbolLoader = TwinCAT.Ads.TypeSystem.SymbolLoaderFactory.Create(ads, TwinCAT.Ads.SymbolLoaderSettings.Default);
            IValueSymbol Symbol = (IValueSymbol)symbolLoader.Symbols[name];
            return Symbol;
        }
        private void AddEvent(TcEvent evt)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Name = "Time";
            try
            { lvi.Text = Convert.ToString(evt.Date); }
            catch (Exception)
            { lvi.Text = ""; }
            eventView1.Items.Insert(0, lvi);
            PrepareListViewItem(lvi);

            try
            { AddListViewSubItem(lvi, "Type", GetEventClassName(evt)); }
            catch (Exception)
            { }
            try
            { AddListViewSubItem(lvi, "Source", evt.get_SourceName(langId)); }
            catch (Exception)
            { }

            try
            { AddListViewSubItem(lvi, "Message", evt.GetMsgString(langId)); }
            catch (Exception)
            { }
        }
        /// <summary>
        /// Prepare the listview item by padding its subitems with empty items
        /// </summary>
        /// <param name="lvi"> ListViewItem to be prepared</param>
        private void PrepareListViewItem(ListViewItem lvi)
        {
            for (int i = 0; i < eventView1.Columns.Count; i++)
                lvi.SubItems.Add("???"); // pad items with question marks.
        }
        /// <summary>
        /// Add one sub item at an indexed position to the ListViewItem
        /// </summary>
        /// <param name="lvi"> Parent item. The item must have been inserted to a ListView control</param>
        /// <param name="name"> Item name (index) of the item. A coulumn with such index must exist in the ListView control</param>
        /// <param name="text"> Display text </param>
        private void AddListViewSubItem(ListViewItem lvi, string name, string text)
        {
            ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
            lvsi.Name = name;
            lvsi.Text = text;
            lvi.SubItems.Insert(lvi.ListView.Columns.IndexOfKey(lvsi.Name), lvsi);
        }
        /// <summary>
        /// Get a textual representation for the event class.
        /// </summary>
        /// <param name="evt">Event object</param>
        /// <returns>Classname</returns>
        private string GetEventClassName(TcEvent evt)
        {
            switch ((TcEventClass)evt.Class)
            {
                case TcEventClass.TCEVENTCLASS_ALARM:
                    return "Alarm";
                case TcEventClass.TCEVENTCLASS_HINT:
                    return "Hint";
                case TcEventClass.TCEVENTCLASS_INSTRUCTION:
                    return "Instruction";
                case TcEventClass.TCEVENTCLASS_MAINTENANCE:
                    return "Maintenance";
                case TcEventClass.TCEVENTCLASS_MESSAGE:
                    return "Message";
                case TcEventClass.TCEVENTCLASS_PARAMERROR:
                    return "Paramerror";
                case TcEventClass.TCEVENTCLASS_STATEINFO:
                    return "State info";
                case TcEventClass.TCEVENTCLASS_WARNING:
                    return "Warning";
                default:
                    return "?";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}


