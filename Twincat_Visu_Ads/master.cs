using System;
using System.Drawing;
using System.Windows.Forms;
using TwinCAT.Ads;
using Twincat_Visu_Ads;

namespace Beckhoff_VS_Visualisation
{
    public partial class master : Form
    {
        public master()
        {
            InitializeComponent();
            main form1 = new main();
            form1.MdiParent = this;
            form1.Show();
        }

        DateTime dt = DateTime.Now;
        private AdsClient ads = new AdsClient();

        internal void ErrorsCounterDisplay(int errors)
         {
            errorsCounterToolStripMenuItem.Text = errors.ToString();
            //get{ return errorsCounterToolStripMenuItem.Text; }
            //set{ errorsCounterToolStripMenuItem.Text = value; Invalidate(); }
         }
        public void master_OnLoad(object sender, EventArgs e)
        {
            
        }
        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main form1 = new main();
            form1.MdiParent = this;
            form1.Show();
        }

        private void rejectsTriggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TriggersReject FormTR = new TriggersReject();
            FormTR.MdiParent = this;
            FormTR.Show();
        }
        private void pLCCONNECTIONSTATUSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdsRouter adsRouter = new AdsRouter();
            adsRouter.MdiParent = this;
            adsRouter.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dt = DateTime.Now;
            dataToolStripMenuItem.Text = dt.ToString();

            if (CheckConnectionWithLocalPLC() == true)
            {
                pLCCONNECTIONSTATUSToolStripMenuItem.Text = ("Connection with PLC OK");
                pLCCONNECTIONSTATUSToolStripMenuItem.BackColor = Color.Green;
            }
            else
            {
                pLCCONNECTIONSTATUSToolStripMenuItem.Text = ("Connection with PLC is missing");
                pLCCONNECTIONSTATUSToolStripMenuItem.BackColor = Color.Red;
            }
        }

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
    }
}
