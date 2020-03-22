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
    public partial class Form21 : Form
    {
        private float x1, y1, x2 = 100, y2 = 50;
        public Form21()
        {
            InitializeComponent();
            x1 = this.Width / 2 - x2 / 2;
            y1 = this.Height / 2 - y2 / 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x1 -= 10;
            y1 -= 5;
            x2 += 20;
            y2 += 10;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            SolidBrush b = new SolidBrush(Color.FromArgb(55, 100, 55));
            dc.FillRectangle(b, x1, y1, x2, y2);
        }
    }
}
