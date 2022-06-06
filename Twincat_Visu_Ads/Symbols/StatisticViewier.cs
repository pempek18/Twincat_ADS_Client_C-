using System;
using System.Drawing;
using System.Windows.Forms;

namespace Twincat_Visu_Ads.Symbols
{
    class StatisticViewier : Control
    {
        private Color color = Color.RoyalBlue;
        private string[] text = new string[7];

        public string Label_1
        {
            get { return text[1]; }
            set { text[1] = value; Invalidate(); }
        }
        public string Label_2
        {
            get { return text[2]; }
            set { text[2] = value; Invalidate(); }
        }
        public string Label_3
        {
            get { return text[3]; }
            set { text[3] = value; Invalidate(); }
        }
        public string Label_4
        {
            get { return text[4]; }
            set { text[4] = value; Invalidate(); }
        }
        public string Label_5
        {
            get { return text[5]; }
            set { text[5] = value; Invalidate(); }
        }
        public string Label_6
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

            text[0] = Text;
            Point p = new Point(Width / 2 - text[0].Length * 7, Height / 20 - 1);
            pe.Graphics.FillRectangle(new SolidBrush(color), ClientRectangle);
            pe.Graphics.DrawString(text[0], Font, new SolidBrush(ForeColor), p);

            p.X = Width / 10 + 10;
            p.Y = Height / 10 + 30;
            pe.Graphics.DrawString(text[1], Font, new SolidBrush(ForeColor), p);

            p.X = Width / 10 + 10;
            p.Y = Height / 10 + 60;
            pe.Graphics.DrawString(text[2], Font, new SolidBrush(ForeColor), p);

            p.X = Width / 10 + 10;
            p.Y = Height / 10 + 90;
            pe.Graphics.DrawString(text[3], Font, new SolidBrush(ForeColor), p);

            p.X = Width / 2 + 50;
            p.Y = Height / 10 + 30;
            pe.Graphics.DrawString(text[4], Font, new SolidBrush(ForeColor), p);

            p.X = Width / 2 + 50;
            p.Y = Height / 10 + 60;
            pe.Graphics.DrawString(text[5], Font, new SolidBrush(ForeColor), p);

            p.X = Width / 2 + 50;
            p.Y = Height / 10 + 90;
            pe.Graphics.DrawString(text[6], Font, new SolidBrush(ForeColor), p);
        }
    }
}
