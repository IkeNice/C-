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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).TabIndex)
            {
                case 0:
                    Form1 newForm1 = new Form1();
                    newForm1.Show();
                    break;
                case 1:
                    Form2 newForm2 = new Form2();
                    newForm2.Show();
                    break;
                case 2:
                    Form3 newForm3 = new Form3();
                    newForm3.Show();
                    break;
                case 3:
                    Form4 newForm4 = new Form4();
                    newForm4.Show();
                    break;
                case 4:
                    Form5 newForm5 = new Form5();
                    newForm5.Show();
                    break;
                case 5:
                    Form6 newForm6 = new Form6();
                    newForm6.Show();
                    break;
                case 6:
                    Form7 newForm7 = new Form7();
                    newForm7.Show();
                    break;
                case 7:
                    Form8 newForm8 = new Form8();
                    newForm8.Show();
                    break;
            }
        }
    }
}
