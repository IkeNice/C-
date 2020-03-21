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
    public partial class Form8 : Form
    {
        int[] masx = new int[100];
        int[] masy = new int[100];
        int i = 0, j = 0, R = 75, maxH, maxW;
        int clickL = 0, clickR = 0, count = 0;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_MouseClick(object sender, MouseEventArgs e)
        {
            maxH = this.Height - R;
            maxW = this.Width - R;
            Graphics g = this.CreateGraphics();
            Random rnd = new Random();
            if (e.Button == MouseButtons.Right)
            {
                masx[i] = rnd.Next(0, maxW);
                masy[i] = rnd.Next(0, maxH);

                SolidBrush b = new SolidBrush(Color.FromArgb(55, 100, 55));
                g.FillEllipse(b, masx[i], masy[i], (int)R, (int)R);
                i += 1;
                count += 1;
                clickR += 1;
                this.label1.Text = "Окружностей: " + count;
                this.label2.Text = "Click: " + clickR;
            }
            if (e.Button == MouseButtons.Left)
            {
                SolidBrush b = new SolidBrush(BackColor);
                g.FillEllipse(b, masx[j], masy[j], (int)R, (int)R);
                j += 1;
                count -= 1;
                if (count == 0)
                {
                    this.label1.Text = "Окружностей: 0";
                }
                else
                {
                    this.label1.Text = "Окружностей: " + count;
                }
                clickL += 1;
                this.label3.Text = "Click left: " + clickL;
            }
        }
    }
}
