using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // need a file dialog to use to open a file
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Text files (*.txt)|*.txt";
            file.ShowDialog();

            if(File.Exists(file.FileName))
            {
                // we have a file run our actions
                var contents = File.ReadAllText(file.FileName);
                label1.Text = $"File loaded: {file.FileName}";

                // clear textbox
                textBox1.Text = string.Empty;

                // convert all to lower
                ConvertAllToLower(contents);

                // find first and last alphabetically
                FirstAndLast(contents);

                // find longest
                FindLongest(contents);

                // most vowels
                FindMostVowels(contents);

                // save to file
                SaveToNewFile();
            }
        }

        /// <summary>
        /// save the contents of the textbox to a file
        /// </summary>
        private void SaveToNewFile()
        {
            string fileName = $"{Guid.NewGuid().ToString().Replace("-", string.Empty)}_contents.txt";
            try
            {
                File.WriteAllText(fileName, textBox1.Text);
            }
            catch (Exception e)
            {
                label1.Text = $"Error saving file: {e.Message}";
            }
            
        }

        private void FindMostVowels(string contents)
        {

            var words = contents.ToLower().Split(" \r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var mostVowels = string.Empty;
            foreach (var w in words)
            {
                if (CountVowels(w) > CountVowels(mostVowels))
                    mostVowels = w;
            }

            StringBuilder l = new StringBuilder();
            l.AppendLine();
            l.AppendLine("====================================");
            l.AppendLine($"Most Vowels: {mostVowels}");

            textBox1.Text += l.ToString();
        }

        private int CountVowels(string i)
        {
            char[] v = new[] { 'a', 'e', 'i', 'o', 'u' };
            var h = 0;
            foreach(var c in i)
            {
                if (v.Contains(c))
                    h++;
            }

            return h;
        }

        private void FindLongest(string contents)
        {
            var words = contents.Split(" \r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var longestWord = string.Empty;
            foreach(var w in words)
            {
                if (w.Length > longestWord.Length)
                    longestWord = w;
            }

            StringBuilder l = new StringBuilder();
            l.AppendLine();
            l.AppendLine("====================================");
            l.AppendLine($"Longest Word: {longestWord}");

            textBox1.Text += l.ToString();
        }

        private void FirstAndLast(string contents)
        {
            var words = contents.Split(" \r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            var first = words.First();
            var last = words.Last();

            StringBuilder l = new StringBuilder();
            l.AppendLine();
            l.AppendLine("====================================");
            l.AppendLine($"First: {first}");
            l.AppendLine($"Last: {last}");

            textBox1.Text += l.ToString();
        }

        private void ConvertAllToLower(string contents)
        {
            textBox1.Text += contents.ToLower();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = string.Empty;
        }
    }
}
