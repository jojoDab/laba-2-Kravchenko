using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public int i1 = Class.a + 1;
        public int j1 = Class.b + 1;
        public int n = 0;

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = Class.a + 1;
            dataGridView1.ColumnCount = Class.b + 1;
            // dataGridView1.Columns[0].HeaderText = "название столбца";

            for (int i = 1; i < i1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = "A" + i;
            }
            for (int j = 1; j < j1; j++)
            {
                dataGridView1.Rows[0].Cells[j].Value = "B" + j;
            }


            for (int i = 1; i < i1; i++)
            {
                for (int j = 1; j < j1; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 1;
                }
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            double z, sr1 = 0, sr2 = 0;
            string f;
            for (int i = 1; i < i1; i++)
            {
                for (int j = 1; j < j1; j++)
                {
                    f = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    z = Convert.ToDouble(f);
                    sr1 += z;
                }
                sr1 = sr1 / j1;
                if (sr2 < sr1)
                {
                    sr2 = sr1;
                    n = i;
                }
                sr1 = 0;
            }
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Pink;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.White;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            double z, min = 9999, max = 0;
            string f;
            double[] x = new double[i1];
            n = 0;

            for (int i = 1; i < i1; i++)
            {
                for (int j = 1; j < j1; j++)
                {
                    f = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    z = Convert.ToDouble(f);
                    if (z < min)
                    {
                        min = z;
                    }
                }

                if (max < min)
                {
                    max = min;
                    n = i;
                }
                min = 9999;
            }
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Yellow;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.White;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            double z, max = 0;
            string f;
            n = 0;

            for (int i = 1; i < i1; i++)
            {
                for (int j = 1; j < j1; j++)
                {
                    f = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    z = Convert.ToDouble(f);
                    if (z > max)
                    {
                        max = z;
                        n = i;
                    }
                }
            }
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Purple;

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.White;
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            //DataGridView dgr = new DataGridView();
            //dgr.Location = new Point(12, 471);
            //dgr.Width = 871;
            //dgr.Height = 279;
            //dgr.RowCount = Class.a + 1;
            //dgr.ColumnCount = Class.b + 1;
            //this.Controls.Add(dgr);



            double z = 0, max = 0, min = 32000;
            string f;
            double[] x = new double[j1];
            double[,] y = new double[i1, j1];
            n = 0;

            for (int j = 1; j < j1; j++)
            {
                for (int i = 1; i < i1; i++)
                {
                    f = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    z = Convert.ToDouble(f);
                    if (z > max)
                    {
                        max = z;
                    }
                }
                x[j - 1] = max;
                max = 0;
            }

            for (int i = 1; i < i1; i++)
            {
                for (int j = 1; j < j1; j++)
                {
                    f = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    z = Convert.ToDouble(f);
                    y[i - 1, j - 1] = z;
                    y[i - 1, j - 1] = x[j - 1] - z;
                    //dgr.Rows[i].Cells[j].Value = y[i - 1, j - 1];//!!!!!
                    if (y[i - 1, j - 1] > max)
                    {
                        max = y[i - 1, j - 1];
                    }
                }
                if (min > max)
                {
                    min = max;
                    n = i;
                }
                max = 0;
            }
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Green;

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.White;
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            double z, min = 9999, max = 0, maxo = 0;
            string f;
            double O;
            int n = 0;
            O = Convert.ToDouble(textBox1.Text);

            for (int i = 1; i < i1; i++)
            {
                for (int j = 1; j < j1; j++)
                {
                    f = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    z = Convert.ToDouble(f);
                    if (z < min) { min = z; }
                    if (z > max) { max = z; }
                }
                z = max * O + min * (1 - O);
                if (z > maxo)
                {
                    maxo = z;
                    n = i;
                }
            }
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Olive;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.White;
        }
    }
}
