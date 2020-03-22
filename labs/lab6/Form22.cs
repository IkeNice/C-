using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form22 : Form
    {
        private float x1, y1, x2, y2;

        private void Form22_Paint(object sender, PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            SolidBrush b1 = new SolidBrush(Color.FromArgb(55, 100, 55));
            SolidBrush b2 = new SolidBrush(Color.FromArgb(255, 0, 255));
            dc.FillRectangle(b1, x1, y1, rWidth, rHeight);
            dc.FillRectangle(b2, x2, y2, rWidth, rHeight);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x1 -= 10;
            y1 -= 5;
            x2 += 10;
            y2 += 5;
            Invalidate();
        }

        private float rWidth = 120, rHeight = 75;
        public Form22()
        {
            InitializeComponent();
            x1 = this.Width / 2 - rWidth;
            y1 = this.Height / 2 - rHeight;
            x2 = x1;
            y2 = y1;
        }

    }
}
