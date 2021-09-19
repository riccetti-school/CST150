using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = string.Empty;
            label3.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int g = int.Parse(textBox1.Text);
                double f = 3.0;
                double pi = 4.0;
                int j = 3;

                while (f < g)
                {
                    if (j % 2 != 0)
                    {
                        pi -= (double)(4 / f);
                        j++;
                    }
                    else
                    {
                        pi += (double)(4 / f);
                        j++;
                    }
                    f += 2;
                }

                label2.Text = $"Approximate value of pi after {g} terms";
                label3.Text = $"= {pi}";
            }
            catch (Exception)
            {
                label2.Text = string.Empty;
                label3.Text = "Invalid term value";
            }
        }
    }
}
