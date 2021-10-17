using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity15
{
    public partial class Form1 : Form
    {

        private bool _monthDone = false;

        enum Colors
        {
            Red,
            Orange,
            Green,
            Blue,
            Black
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillYear();

            FillMonth();

            FillColor();
        }

        private void FillColor()
        {
            comboBox4.Items.Clear();
            foreach (string name in Enum.GetNames(typeof(Colors)))
            {
                comboBox4.Items.Add(name);
            }
            comboBox4.SelectedIndex = 0;
        }

        private void FillMonth()
        {
            var months = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            comboBox2.Items.Clear();
            foreach (var month in months)
            {
                comboBox2.Items.Add(month);
            }
            comboBox2.SelectedIndex = 0;
        }

        private void FillYear()
        {
            var baseYear = 1990;
            comboBox1.Items.Clear();

            while (baseYear <= DateTime.Now.Year)
            {
                comboBox1.Items.Add(baseYear.ToString());

                baseYear++;
            }

            _monthDone = true;

            // select first one
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_monthDone) return;

            // add the days for this month
            var month = ((ComboBox)sender).SelectedItem.ToString();
            var monthNumber = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;
            var days = DateTime.DaysInMonth(int.Parse(comboBox1.SelectedItem.ToString()), monthNumber);
            var dayCounter = 1;
            comboBox3.Items.Clear();
            while (dayCounter <= days)
            {
                comboBox3.Items.Add(dayCounter.ToString());
                dayCounter++;
            }
            comboBox3.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ResultForm().Show(this);
        }
    }
}
