using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        private int width, X = 50;
        private int height, Y = 50;
        private Color myColor;

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            switch (menuItem.Text)
            {
                case "small":
                    width = 100;
                    height = 100;
                    break;
                case "medium":
                    width = 250;
                    height = 250;
                    break;
                case "big":
                    width = 500;
                    height = 500;
                    break;
            }
            Invalidate();
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var contextMenuItem = sender as ToolStripMenuItem;
            switch (contextMenuItem.Text)
            {
                case "red":
                    myColor = Color.Red;
                    break;
                case "green":
                    myColor = Color.Green;
                    break;
                case "blue":
                    myColor = Color.Blue;
                    break;
            }
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point myPoint = new Point(e.X, e.Y);
            if ((e.Button.ToString() == "Right") && (myPoint.X > X) && (myPoint.X < X + width) && (myPoint.Y > Y) && (myPoint.Y < Y + height))
                contextMenuStrip1.Show(this, myPoint);
        }

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            myColor = Color.Black;
            width = 100;
            height = 100;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            SolidBrush b = new SolidBrush(myColor);
            dc.FillRectangle(b, X, Y, width, height);
        }
    }
}
