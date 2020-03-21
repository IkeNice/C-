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
    public partial class Form6 : Form
    {
        double x1 = 800, x2, y1 = 500, y2;
        int maxH, maxW;
        double speed, angle;
        private void Form6_MouseMove(object sender, MouseEventArgs e)
        {
            maxH = this.Height;
            maxW = this.Width;
            x2 = e.X;
            y2 = e.Y;
            angle = GetAngle();
        }

        public Form6()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            speed = 10;
            angle = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x1 += speed * Math.Sin(angle);
            y1 += speed * Math.Cos(angle);
            Pen p;//Объявляем перо
            Graphics g = this.CreateGraphics();
            Color clr = new Color();
            clr = Color.FromArgb(0, 0, 100);
            p = new Pen(clr);
            g.Clear(Color.White);
            g.DrawEllipse(p, (int)x1, (int)y1, 50, 50);
        }
        double GetAngle()
        {
            return Math.Atan2((x1 - x2), (y1 - y2));
        }
    }
}
