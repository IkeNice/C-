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
    public partial class Form4 : Form
    {
        double x1 = 100, red = 0, green = 0, blue = 0, y1 = 100, R = 50;
        bool f = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (f == true)
                f = false;
            else f = true;
        }

        int speedx = 10, speedy = 10;
        int maxH, maxW, speedR = 20;
        public Form4()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
                timer1.Enabled = true;
            else timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            maxW = this.Width;
            maxH = this.Height;
            Graphics g = this.CreateGraphics();
            g.Clear(BackColor);

            if (x1 > maxW)
                speedx *= (-1);
            else if (x1 < 0)
                speedx *= (-1);

            if (y1 > maxH)
                speedy *= (-1);
            else if (y1 < 0)
                speedy *= (-1);
            if (f == true)
            {
                if (R > 250)
                    speedR *= (-1);
                if (R < 30)
                    speedR *= (-1);
                R += speedR;
            }
            x1 += speedx;
            y1 += speedy;
            SolidBrush b = new SolidBrush(Color.FromArgb((int)red, (int)green, (int)blue));
            g.FillEllipse(b, (int)x1, (int)y1, (int)R, (int)R);
        }
    }
}
