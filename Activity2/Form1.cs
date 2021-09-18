using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var inches = double.Parse(textBox1.Text);
                double cm = 0.0;

                cm = inches * 2.54;
                textBox2.Text = cm.ToString("F3");
            }
            catch(Exception ex)
            {
                textBox2.Text = string.Empty;
                label3.Text = $"Error: {ex.Message}";
            }
        }
    }
}
