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
        private int xWidth, yHeight;
        public Form21()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            xWidth += 10;
            yHeight += 5;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            SolidBrush b = new SolidBrush(Color.FromArgb(55, 100, 55));
            dc.FillRectangle(b, (float)10, (float)100, (float)xWidth, (float)yHeight);

        }
    }
}
