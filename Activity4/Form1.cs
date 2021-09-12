using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity4
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConvertSeconds(textBox1.Text);
        }

        private void ConvertSeconds(string v)
        {
            // make sure the text is a number value
            double val;
            if(double.TryParse(v, out val) && val > -1)
            {
                if(val < 60)
                {
                    label2.Text = $"You entered {val} second(s).";
                }
                else if(val >= 60 && val < 3600)
                {
                    var minutes = val / 60;
                    label2.Text = $"You entered {minutes} minute(s).";
                }
                else if(val >= 3600 && val < 86400)
                {
                    var hours = (val / 60) / 60;
                    label2.Text = $"You entered {hours} hour(s).";
                }
                else if(val >- 86400)
                {
                    var days = ((val / 60) / 60) / 24;
                    label2.Text = $"You entered {days} day(s).";
                }
            }
            else
            {
                label2.Text = $"Value entered is not valid: [{v}]";
            }
        }
    }
}
