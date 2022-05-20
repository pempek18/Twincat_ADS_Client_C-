using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinCAT.Ads;





namespace Beckhoff_VS_Visualisation
{
    public partial class Form1 : Form
    {
        int ADS_Port = 851;
        public Form1()
        {
            InitializeComponent();
        }
        private AdsClient ads = new AdsClient();
        bool testVarRead;
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
            textBox1.Text = ((Int32)ads.ReadAny(ads.CreateVariableHandle("prgAlarms.HMI_Alarms_Counter"), typeof(Int32))).ToString();
            label2.Text = dt.ToString();
            //Dwie linijki poniżej są błędna ponieważ nie potrafię odczytać wartości globalnych
            label5.Text = ((Single)ads.ReadAny(ads.CreateVariableHandle("Global_Variables.rEff1"), typeof(Single))).ToString();
            label4.Text = ((int)ads.ReadAny(ads.CreateVariableHandle("Global_Variables.stDeviceCtrl.iBPM"), typeof(ST_DeviceCtrl))).ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ads.WriteAny(ads.CreateVariableHandle("prgAlarms.test");, true);

            testVarRead = (bool)ads.ReadAny(ads.CreateVariableHandle("prgAlarms.test");, typeof(bool));
            if (testVarRead)
            {

                button1.BackColor = Color.Green;
                button2.BackColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ads.WriteAny(ads.CreateVariableHandle("prgAlarms.test");, false);
            
            testVarRead = (bool)ads.ReadAny(ads.CreateVariableHandle("prgAlarms.test");, typeof(bool));
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
                ads.Connect(ADS_Port);
                if (ads.IsConnected == true)
                {
                    label1.Text = ("Connection OK");
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
