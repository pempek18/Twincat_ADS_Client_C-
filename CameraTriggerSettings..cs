using System;
using System.Drawing;
using System.Windows.Forms;

namespace Beckhoff_VS_Visualisation
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        bool BoolVar;
        public string Textbox_1
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; Invalidate(); }
        }
        public string Textbox_2
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; Invalidate(); }
        }
        public string Textbox_3
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; Invalidate(); }
        }
        public bool DisableBlowerVar
        {
            get { return BoolVar; }
            set { BoolVar = value; Invalidate();  }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = Textbox_1;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (BoolVar)
            {
                BoolVar = false;
                button1.BackColor = Color.Red;
            }
            else
            {
                BoolVar = true;
                button1.BackColor = Color.Green;
            }
        }
    }
}
