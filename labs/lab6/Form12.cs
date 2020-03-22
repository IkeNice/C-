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
    public partial class Form12 : Form
    {
        int x, y;
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black);
            x = e.X;
            y = e.Y;
            if (e.Button == MouseButtons.Right)
            {
                g.DrawLine(p, 0, 0, x, y);
            }
        }
    }
}
