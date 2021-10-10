using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder results = new StringBuilder();

            if (checkBox1.Checked)
                results.AppendLine("Option 1 selected");
            if(checkBox2.Checked)
                results.AppendLine("Option 2 selected");
            if(checkBox3.Checked)
                results.AppendLine("Option 3 selected");

            if (radioButton1.Checked)
                results.AppendLine("Radio 1 selected");
            if(radioButton2.Checked)
                results.AppendLine("Radio 2 selected");
            if(radioButton3.Checked)
                results.AppendLine("Radio 3 selected");

            foreach(var i in listBox1.SelectedItems)
            {
                results.AppendLine($"{i} selected");
            }

            MessageBox.Show(results.ToString(), "Results", MessageBoxButtons.OK);
        }
    }
}
