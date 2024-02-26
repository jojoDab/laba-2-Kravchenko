using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       public static int a, b;

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridView dgr = new DataGridView();
            dgr.Location = new Point(12, 471);
            dgr.Width = 871;
            dgr.Height = 279;
            dgr.RowCount = 5;
            dgr.ColumnCount = 5;
            this.Controls.Add(dgr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               Class.a = Convert.ToInt32(textBox1.Text);
               Class.b = Convert.ToInt32(textBox2.Text);
                if (Class.a != 0 || Class.b != 0)
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    textBox1.Text = "0.4";
                    a = Convert.ToInt32(textBox1.Text);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Введите ненулевые целые значения!", "Ошибка...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
