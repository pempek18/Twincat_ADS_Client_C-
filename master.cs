using System;
using System.Windows.Forms;

namespace Beckhoff_VS_Visualisation
{
    public partial class master : Form
    {
        public master()
        {
            InitializeComponent();
            Form1 form1 = new Form1();
            form1.MdiParent = this;
            form1.Show();
        }  
        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.MdiParent = this;
            form1.Show();
        }

        private void rejectsTriggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TriggersReject FormTR = new TriggersReject();
            FormTR.MdiParent = this;
            FormTR.Show();
        }
    }
}
