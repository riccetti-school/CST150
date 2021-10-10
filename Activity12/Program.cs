using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity12
{
    class Program
    {
        static void Main(string[] args)
        {

            // load file
            var data = File.ReadAllText("data.txt");

            // split to words
            var words = data.Split(" \r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // check words
            if (words.Any())
            {
                words.ToList().ForEach(c => CheckWord(c));
            }

            Console.ReadKey();

        }

        /// <summary>
        /// Given a text file, refer to “Activity 12 Example” and write a program (console application) that counts the number of words that end with the letter "t" or "e" (not case sensitive).
        /// </summary>
        /// <param name="c"></param>
        private static void CheckWord(string c)
        {
            var last = c.Last().ToString().ToLower();
            var lastminusone = c.ToArray()[c.Count() - 1].ToString().ToLower();
            var list = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            // check the last character
            if (last == "t" || last == "e")
            { 
                Console.WriteLine($"[{c}] ends in 't' or 'e'");
                return;
            }

            if(lastminusone == "t" || lastminusone == "e" && !list.Contains(last))
                Console.WriteLine($"[{c}] ends in 't' or 'e'");
        }
    }
}
