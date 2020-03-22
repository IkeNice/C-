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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).TabIndex)
            {
                case 11:
                    Form11 form11 = new Form11();
                    form11.Show();
                    break;
                case 12:
                    Form12 form12 = new Form12();
                    form12.Show();
                    break;
                case 13:
                    Form13 form13 = new Form13();
                    form13.Show();
                    break;
                case 21:
                    Form21 form21 = new Form21();
                    form21.Show();
                    break;
                case 22:
                    Form22 form22 = new Form22();
                    form22.Show();
                    break;
            }

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.panel1.Top = 0;
            this.panel1.Left = 0;
            this.panel1.Height = this.Height;
            this.panel1.Width = this.Width / 2;

            this.panel2.Top = 0;
            this.panel2.Left = this.Width / 2;
            this.panel2.Height = this.Height;
            this.panel2.Width = this.Width / 2;
        }
    }
}
