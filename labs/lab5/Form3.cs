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
    public partial class Form3 : Form
    {
        double X, Y, Z;
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                X = Convert.ToDouble(textBox1.Text);
                Y = Convert.ToDouble(textBox2.Text);
                Graphics g = this.CreateGraphics();
                g.Clear(BackColor);
                Random rnd = new Random();
                Pen p;
                for (int i = 0; i < X + Y; i++)
                {
                    p = new Pen(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                    g.DrawBezier(p, rnd.Next(0, 255), rnd.Next(300, 600), rnd.Next(350, 900), rnd.Next(500, 600), rnd.Next(1000, 1200), rnd.Next(200, 255), rnd.Next(100, 255), rnd.Next(200, 955));
                }
            }
            catch
            {
                MessageBox.Show("Проверьте правильность ввода чисел!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                X = Convert.ToDouble(textBox1.Text);
                Y = Convert.ToDouble(textBox2.Text);
                Z = Convert.ToDouble(textBox3.Text);
                Graphics g = this.CreateGraphics();
                g.Clear(BackColor);
                Random rnd = new Random();
                Pen p;
                for (int i = 0; i < X + Y + Z; i++)
                {
                    p = new Pen(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                    SolidBrush b = new SolidBrush(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                    g.FillEllipse(b, rnd.Next(200, 1700), rnd.Next(200, 900), rnd.Next(50, 100), rnd.Next(50, 100));
                }
            }
            catch
            {
                MessageBox.Show("Проверьте правильность ввода чисел!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.Clear(BackColor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                X = Convert.ToDouble(textBox1.Text);
                Graphics g = this.CreateGraphics();
                g.Clear(BackColor);
                Random rnd = new Random();
                Pen p;
                for (int i = 0; i < X; i++)
                {
                    p = new Pen(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                    g.DrawArc(p, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                }
            } catch
            {
                MessageBox.Show("Проверьте правильность ввода чисел!");
            }
        }
    }
}
