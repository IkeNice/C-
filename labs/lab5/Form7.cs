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
    public partial class Form7 : Form
    {
        int x1 = 200, y1 = 200, R = 75;

        private void Form7_Shown(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.FromArgb(0, 100, 100));
            g.FillEllipse(b, (int)x1, (int)y1, (int)R, (int)R);
        }

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_KeyDown(object sender, KeyEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            if (e.KeyCode == Keys.Right)
            {
                x1 += 10;
                g.Clear(BackColor);
                SolidBrush b = new SolidBrush(Color.FromArgb(0, 100, 100));
                g.FillEllipse(b, (int)x1, (int)y1, (int)R, (int)R);
            }
            if (e.KeyCode == Keys.Down)
            {
                y1 += 10;
                g.Clear(BackColor);
                SolidBrush b = new SolidBrush(Color.FromArgb(0, 100, 100));
                g.FillEllipse(b, (int)x1, (int)y1, (int)R, (int)R);
            }
            if (e.KeyCode == Keys.Up)
            {
                y1 -= 10;
                g.Clear(BackColor);
                SolidBrush b = new SolidBrush(Color.FromArgb(0, 100, 100));
                g.FillEllipse(b, (int)x1, (int)y1, (int)R, (int)R);
            }
            if (e.KeyCode == Keys.Left)
            {
                x1 -= 10;
                g.Clear(BackColor);
                SolidBrush b = new SolidBrush(Color.FromArgb(0, 100, 100));
                g.FillEllipse(b, (int)x1, (int)y1, (int)R, (int)R);
            }
        }
    }
}
