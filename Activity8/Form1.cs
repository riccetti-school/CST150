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
        private double CarbCalries(double carbGrams)
        {
            return _convert.ToCarbCalories(carbGrams);
        }

    }
}
