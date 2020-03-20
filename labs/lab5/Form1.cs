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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void redraw_Click(object sender, EventArgs e)
        {
            double x, y;
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.Clear(BackColor);
            try
            {
                x = Convert.ToDouble(textBox1.Text);
                y = Convert.ToDouble(textBox2.Text);

                Pen blackPen = new Pen(Color.Black, 3);

                // Create location and size of ellipse.
                int width = 100;
                int height = 100;

                // Draw ellipse to screen.
                formGraphics.DrawEllipse(blackPen, (int)x + 50, (int)y + 50, width, height);
            } catch
            {
                MessageBox.Show("Проверьте правильность ввода чисел!");
            }

        }

    }
}
