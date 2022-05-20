using System;
using System.Drawing;
using System.Windows.Forms;
using TwinCAT.Ads;
using TwinCAT.TypeSystem;


namespace Beckhoff_VS_Visualisation
{
    public partial class Form1 : Form
    {
        //AmsPort ADS_Port = 851;
        //AmsNetId AMS_NetID;
        DateTime dt;
        /*LIST OF PLC VARIABLE USED IN PROJECT*/
        IValueSymbol prgAlarms_test;
        IValueSymbol bResetCnts;

        public Form1()
        {
            InitializeComponent();
        }
        private AdsClient ads = new AdsClient();

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckConnectionWithLocalPLC();

            try
            {
                prgAlarms_test  = GetAdsVariable("prgAlarms.test");
                bResetCnts = GetAdsVariable(".bResetCnts");
            }
            catch(Exception error2)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dt = DateTime.Now;
            try
            {
                textBox1.Text = GetAdsVariableValueString<Int32>("prgAlarms.HMI_Alarms_Counter");
                label2.Text = dt.ToString();
                label4.Text = GetAdsVariableValueString<int>(".stDeviceCtrl.iBPM"); 

                label10.Text = GetAdsVariableValueString<UInt32>(".udiTriggersCnt_1"); 
                label11.Text = GetAdsVariableValueString<UInt32>(".udiRejectsCnt1"); 
                label12.Text = GetAdsVariableValueString<Single>(".rEff1"); 
                
                label15.Text = GetAdsVariableValueString<UInt32>(".udiTriggersCnt_2"); 
                label14.Text = GetAdsVariableValueString<UInt32>(".udiRejectsCnt2"); 
                label13.Text = GetAdsVariableValueString<Single>(".rEff2"); 

                label22.Text = GetAdsVariableValueString<UInt32>(".udiTriggersCnt_3"); 
                label21.Text = GetAdsVariableValueString<UInt32>(".udiRejectsCnt3"); 
                label20.Text = GetAdsVariableValueString<Single>(".rEff3"); 

                label29.Text = GetAdsVariableValueString<UInt32>(".udiTriggersCnt_4"); 
                label28.Text = GetAdsVariableValueString<UInt32>(".udiRejectsCnt4"); 
                label27.Text = GetAdsVariableValueString<Single>(".rEff4");

                label36.Text = GetAdsVariableValueString<UInt32>(".udiInfeedCnt");
                label35.Text = GetAdsVariableValueString<UInt32>(".udiRejectsCnt");
                label34.Text = GetAdsVariableValueString<Single>(".rEff7");
            }
            catch (Exception error1)
            {
                timer1.Enabled = false;
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Application can not read PLC Variables \nYes to Close App \nNo to try again\nMessage Below :\n" + error1;
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    // Closes the parent form.
                    timer1.Enabled = true;
                }
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
        /********************FUNCTIONS*************************************/
        void CheckConnectionWithLocalPLC()
        {
            try
            {
                // Connect to local TwinCAT System Service
                //ads.Connect(ADS_Port);
                ads.Connect(AmsNetId.Local, 851);
                if (ads.IsConnected == true)
                {
                    label1.Text = ("Connection with PLC OK");
                    label1.BackColor = Color.Green;
                }
                else
                {
                    label1.Text = ("Connection with PLC is missing");
                    label1.BackColor = Color.Red;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString());
            }
        }

        string GetAdsVariableValueString<T>(string name)
        {
           return ((T)ads.ReadAny(ads.CreateVariableHandle(name), typeof(T))).ToString();
        }

        IValueSymbol GetAdsVariable(string name)
        {
            var symbolLoader = TwinCAT.Ads.TypeSystem.SymbolLoaderFactory.Create(ads, TwinCAT.SymbolLoaderSettings.Default);
            IValueSymbol Symbol = (IValueSymbol)symbolLoader.Symbols[name];
            return Symbol;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = "Reset\n" + dt.ToString();
            bResetCnts.WriteValue(true);
        }
    }
}


