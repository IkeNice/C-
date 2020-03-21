using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form5 : Form
    {
        private int r = 50;
        public Form5()
        {
            InitializeComponent();
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form5_MouseMove);
        }

        private void Form5_MouseMove(object sender, MouseEventArgs e)
        {
            Refresh();
            SolidBrush b = new SolidBrush(Color.FromArgb(0, 0, 0));
            Graphics g = CreateGraphics();
            g.FillEllipse(b, e.X - r, e.Y - r, r, r);
            Application.DoEvents();
        }
    }
}
