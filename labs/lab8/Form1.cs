using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }


        private void menuStrip1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Пункт меню");
        }


        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void моеДействиеToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Будет выведено сообщение";
        }

        private void моеДействиеToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "wait";
        }


        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Show(this, MousePosition.X, MousePosition.Y - 25);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены ?", "Вопрос",
             MessageBoxButtons.YesNo
             , MessageBoxIcon.Question
                , MessageBoxDefaultButton.Button2
             ) == DialogResult.Yes)
                this.Close();

        }

        private void выходToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Закрыта Форма";
        }

        private void выходToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "wait";
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Save changes");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox1.Text);
            textBox1.Text = "";
        }



        private void Add_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(b_add, "Кнопка добавления в чек бокс ");
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Список добавленных слов");
        }



        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(listBox1.Text);
            listBox1.Items.Remove(listBox1.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Insert(0, comboBox1.Text);
            comboBox1.Items.Remove(comboBox1.SelectedItem);
            comboBox1.Text = "";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button2, "Перенесем слово в чекс бокс ");
        }

        private void моеДействиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Text format (*.txt)|*.txt|Rich Text (*.rtf)|*.rtf";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                // если выбрали текст
                if (fd.FilterIndex == 1)
                    richTextBox1.LoadFile(fd.FileName, RichTextBoxStreamType.PlainText);
                else
                    richTextBox1.LoadFile(fd.FileName, RichTextBoxStreamType.RichText);
            }

        }

        private void сохранитьСодержимоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Text format (*.txt)|*.txt|Rich Text (*.rtf)|*.rtf";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                // если выбрали текст
                if (fd.FilterIndex == 1)
                    richTextBox1.SaveFile(fd.FileName, RichTextBoxStreamType.PlainText);
                else
                    richTextBox1.SaveFile(fd.FileName, RichTextBoxStreamType.RichText);
            }

        }
    }
}
