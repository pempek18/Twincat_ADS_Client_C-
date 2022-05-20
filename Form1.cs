using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinCAT.Ads;





namespace Beckhoff_VS_Visualisation
{
    public partial class Form1 : Form
    {
        //AmsPort ADS_Port = 851;
        AmsNetId AMS_NetID;
        int i=0;
        Single j = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private AdsClient ads = new AdsClient();
        public struct ST_DeviceCtrl
        {
            public int iBPM { get; }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CheckConnectionWithLocalPLC();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckConnectionWithLocalPLC();
            DateTime dt;
            dt = DateTime.Now;
            try
            {
                textBox1.Text = ((Int32)ads.ReadAny(ads.CreateVariableHandle("prgAlarms.HMI_Alarms_Counter"), typeof(Int32))).ToString();
                label2.Text = dt.ToString();
                // Create Symbol information (Symbol 'i : INT' in PLC Global Variables list.
                var symbolLoader = TwinCAT.Ads.TypeSystem.SymbolLoaderFactory.Create(ads, TwinCAT.SymbolLoaderSettings.Default);
                TwinCAT.TypeSystem.IValueSymbol gvlIntSymbol = (TwinCAT.TypeSystem.IValueSymbol)symbolLoader.Symbols["GVL.i"];
                i++;
                // Take 10 Values (0..9) and write them to GVL.i
                gvlIntSymbol.WriteValue(i);

                label5.Text = ((Single)ads.ReadAny(ads.CreateVariableHandle(".rEff1"), typeof(Single))).ToString();
                label4.Text = ((int)ads.ReadAny(ads.CreateVariableHandle(".stDeviceCtrl.iBPM"), typeof(int))).ToString();
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
            bool testVarRead;
            ads.WriteAny(ads.CreateVariableHandle("prgAlarms.test"), true);

            testVarRead = (bool)ads.ReadAny(ads.CreateVariableHandle("prgAlarms.test"), typeof(bool));
            if (testVarRead)
            {

                button1.BackColor = Color.Green;
                button2.BackColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool testVarRead;
            ads.WriteAny(ads.CreateVariableHandle("prgAlarms.test"), false);
            
            testVarRead = (bool)ads.ReadAny(ads.CreateVariableHandle("prgAlarms.test"), typeof(bool));
            if (!testVarRead)
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
    }
}

//Different Type of Reading Connecting to Variable in PLC
//var symbolLoader1 = TwinCAT.Ads.TypeSystem.SymbolLoaderFactory.Create(ads, TwinCAT.SymbolLoaderSettings.Default);
//TwinCAT.TypeSystem.IValueSymbol gvlRealSymbol = (TwinCAT.TypeSystem.IValueSymbol)symbolLoader1.Symbols["Global_Variables.rEff1"];
//j++;
//// Take 10 Values (0..9) and write them to GVL.i
//gvlRealSymbol.WriteValue(j);
