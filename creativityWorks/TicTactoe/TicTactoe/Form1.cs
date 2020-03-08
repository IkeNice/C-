using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTactoe
{
    public partial class Form1 : Form
    {
        //private int x = 12, y = 12;
        private Button[,] buttons = new Button[3, 3];
        private int player;
        public Form1()
        {
            InitializeComponent();
            this.Height = 450;
            this.Width = 350;
            player = 1;
            label1.Text = "Текущий ход: Игрок 1";
            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(100, 100);
                }
            }
            setButtons();

        }

        private void setButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Location = new Point(12 + 106 * j, 12 + 106 * i);
                    buttons[i, j].Click += button1_Click;
                    buttons[i, j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 60);
                    buttons[i, j].Text = "";
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sender.GetType().GetProperty("Text").SetValue(sender, "x");
            player = 0;
   
            label1.Text = "Текущий ход: Игрок 2";
            bot();
            sender.GetType().GetProperty("Enabled").SetValue(sender, false);
            checkWin();
        }

        private void bot()
        {
            Random rnd = new Random();
            for (int k=0; k<100; ++k)
            {
               int i = rnd.Next(0, 3);
               int j = rnd.Next(0, 3);
                if (buttons[i,j].Text=="")
                { 
                    buttons[i, j].Text = "о";
                    buttons[i, j].Enabled = false;
                    break;
                }
                  
            }
            player = 1;
            label1.Text = "Текущий ход: Игрок 1";

        }
        private void checkWin()
        {

            if (buttons[0, 0].Text == buttons[0, 1].Text && buttons[0, 1].Text == buttons[0, 2].Text)
            {

                if (buttons[0, 0].Text == "x")
                {
                    MessageBox.Show("Вы победили!");
                    return;
                }
            }
            if (buttons[1, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[1, 2].Text)
            {
                if (buttons[1, 0].Text == "x")
                    MessageBox.Show("Вы победили!");
                if (buttons[1, 0].Text == "о")
                    MessageBox.Show("Вы проиграли!");

            }
            if (buttons[2, 0].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[2, 0].Text == "x")
                    MessageBox.Show("Вы победили!");
                if (buttons[2, 0].Text == "о")
                    MessageBox.Show("Вы проиграли!");
            }
            if (buttons[0, 0].Text == buttons[1, 0].Text && buttons[1, 0].Text == buttons[2, 0].Text)
            {
                if (buttons[0, 0].Text == "x")
                    MessageBox.Show("Вы победили!");
                if (buttons[0, 0].Text == "о")
                    MessageBox.Show("Вы проиграли!");
            }
            if (buttons[0, 1].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 1].Text)
            {
                if (buttons[0, 1].Text == "x")
                    MessageBox.Show("Вы победили!");
                if (buttons[0, 1].Text == "о")
                    MessageBox.Show("Вы проиграли!");
            }
            if (buttons[0, 2].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 2].Text == "x")
                    MessageBox.Show("Вы победили!");
                if (buttons[0, 2].Text == "о")
                    MessageBox.Show("Вы проиграли!");
            }
            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 0].Text == "x")
                    MessageBox.Show("Вы победили!");
                if (buttons[0, 0].Text == "о")
                    MessageBox.Show("Вы проиграли!");
            }
            if (buttons[2, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[0, 2].Text)
            {
                if (buttons[2, 0].Text == "x")
                    MessageBox.Show("Вы победили!");
                if (buttons[2, 0].Text == "о")
                    MessageBox.Show("Вы проиграли!");
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            label1.Text = "Текущий ход: Игрок 1";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
