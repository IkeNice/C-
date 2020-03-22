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
    public partial class Form13 : Form
    {
        int x, y;
        bool f = false;
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black);
            if (f == true)
                g.DrawLine(p, x, y, e.X, e.Y);
            else
            {
                g.DrawLine(p, e.X, e.Y, e.X, e.Y);
                f = true;
            }
            x = e.X;
            y = e.Y;
        }
    }
}
