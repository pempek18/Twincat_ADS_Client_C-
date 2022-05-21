using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Beckhoff_VS_Visualisation
{
     class StatisticViewier : System.Windows.Forms.Control
    {
        private Color color = Color.RoyalBlue;
        private String[] text = new string[7];

        public String Label_1
        {
            get { return text[1]; }
            set { text[1] = value; Invalidate(); }
        }
        public String Label_2
        {
            get { return text[2]; }
            set { text[2] = value; Invalidate(); }
        }
        public String Label_3
        {
            get { return text[3]; }
            set { text[3] = value; Invalidate(); }
        }
        public String Label_4
        {
            get { return text[4]; }
            set { text[4] = value; Invalidate(); }
        }
        public String Label_5
        {
            get { return text[5]; }
            set { text[5] = value; Invalidate(); }
        }
        public String Label_6
        {
            get { return text[6]; }
            set { text[6] = value; Invalidate(); }
        }
        public Color BZBackColor
        {
            get { return color; }
            set { color = value; Invalidate(); }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            

            text[0] = this.Text;
            Point p = new Point(((this.Width / 2) - 50), (this.Height / 20) - 1);
            pe.Graphics.FillRectangle(new SolidBrush(color), ClientRectangle);
            pe.Graphics.DrawString(text[0], this.Font, new SolidBrush(this.ForeColor), p);

            p.X = ((this.Width / 10) + 10);
            p.Y = ((this.Height / 10) + 30);
            pe.Graphics.DrawString(text[1], this.Font, new SolidBrush(this.ForeColor), p);

            p.X = ((this.Width / 10) + 10);
            p.Y = ((this.Height / 10) + 60);
            pe.Graphics.DrawString(text[2], this.Font, new SolidBrush(this.ForeColor), p);

            p.X = ((this.Width / 10) + 10);
            p.Y = ((this.Height / 10) + 90);
            pe.Graphics.DrawString(text[3], this.Font, new SolidBrush(this.ForeColor), p);

            p.X = ((this.Width / 2) + 10);
            p.Y = ((this.Height / 10) + 30);
            pe.Graphics.DrawString(text[4], this.Font, new SolidBrush(this.ForeColor), p);

            p.X = ((this.Width / 2) + 10);
            p.Y = ((this.Height / 10) + 60);
            pe.Graphics.DrawString(text[5], this.Font, new SolidBrush(this.ForeColor), p);

            p.X = ((this.Width / 2) + 10);
            p.Y = ((this.Height / 10) + 90);
            pe.Graphics.DrawString(text[6], this.Font, new SolidBrush(this.ForeColor), p);

            
        }
    }
}
