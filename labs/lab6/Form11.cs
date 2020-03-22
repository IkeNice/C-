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
    public partial class Form11 : Form
    {
        int x, y;
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            x = e.X;
            y = e.Y;
            Font aFont = new Font("Forte", 12, FontStyle.Bold);
            if (e.Button == MouseButtons.Left)
                g.DrawString("Левая кнопка мыши ", aFont, Brushes.Black, x, y);
            else
            {
                g.DrawString(" Правая кнопка мыши ", aFont, Brushes.Black, x, y);
            }
        }
    }
}
