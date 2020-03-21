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
        double x1 = 800, x2, y1 = 300, y2;
        double angle;

        private void timer1_Tick(object sender, EventArgs e)
        {
            x1 += speed * Math.Sin(angle);
            y1 += speed * Math.Cos(angle);
            Pen p;//Объявляем перо
            Color clr = new Color();
            Graphics g = this.CreateGraphics();
            clr = Color.FromArgb(0, 0, 100);
            p = new Pen(clr);
            g.Clear(BackColor);
            SolidBrush b = new SolidBrush(Color.FromArgb(100, 0, 100));
            g.FillEllipse(b, (int)x1, (int)y1, 50, 50);
        }

        double speed;
        public Form6()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            speed = 5;
            angle = 0;
        }
        double GetAngle()
        {
            return Math.Atan2((x1 - x2), (y1 - y2));
        }
        private void Form6_MouseMove(object sender, MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;
            angle = Math.Atan2((x1 - x2), (y1 - y2));
        }
    }
}
