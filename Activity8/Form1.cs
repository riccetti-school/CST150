using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity8
{
    public partial class Form1 : Form
    {

        private CalorieConvert _convert = new CalorieConvert();

        public Form1()
        {
            InitializeComponent();

            // usability items
            // users do not need to access these textboxes
            textBox2.Enabled = false;
            textBox4.Enabled = false;
        }


        /// <summary>
        /// this is a wrapper function for the convert class.  This is not really needed
        /// as the convert class does this, however I wanted to make sure there
        /// was a function which matched the signature in the activity
        /// </summary>
        /// <param name="fatGrams"></param>
        /// <returns></returns>
        private double FatCalories(double fatGrams)
        {
            return _convert.ToFatCalories(fatGrams);
        }

        /// <summary>
        /// this is a wrapper funtion for the convert class
        /// </summary>
        /// <param name="carbGrams"></param>
        /// <returns></returns>
        private double CarbCalories(double carbGrams)
        {
            return _convert.ToCarbCalories(carbGrams);
        }

        /// <summary>
        /// this button handles the convert action for fat grams
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double val = double.Parse(textBox1.Text);
                textBox2.Text = FatCalories(val).ToString();
            }
            catch (Exception)
            {
                textBox2.Text = "Invalid conversion..";
            }
        }

        /// <summary>
        /// this function handles the carb convert action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double val = double.Parse(textBox3.Text);
                textBox4.Text = CarbCalories(val).ToString();
            }
            catch (Exception)
            {
                textBox4.Text = "Invalid conversion..";
            }
        }
    }
}
