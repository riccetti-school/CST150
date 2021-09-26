using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity8
{
    /// <summary>
    /// this is a helper class which will do basic calorie conversion for you
    /// you can give it fat grams or carb grams and pass that to the correct function
    /// to get the calories for those items
    /// </summary>
    public class CalorieConvert
    {

        public CalorieConvert() { }

        /// <summary>
        /// this function will take the count of fat grams and convert that
        /// to total number of calories
        /// </summary>
        /// <param name="fatGrams"></param>
        /// <returns></returns>
        public double ToFatCalories(double fatGrams)
        {
            try
            {
                return (fatGrams * 9);
            }
            catch (Exception)
            {
                return 0;
            }
        }


        /// <summary>
        /// this function will take the total number of 
        /// carb grams and convert those to total number of
        /// calories
        /// </summary>
        /// <param name="carbGrams"></param>
        /// <returns></returns>
        public double ToCarbCalories(double carbGrams)
        {
            try
            {
                return (carbGrams * 4);
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
