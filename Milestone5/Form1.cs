using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone4
{
    public partial class Form1 : Form
    {

        private InventoryManager _im = new InventoryManager();
        private static Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new InventoryManagerUnitTests().RunTests();
        }
                
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// add a random item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            _im.Add(new ItemObj
            {
                Description = RandomString(10),
                IsDamaged = false,
                PackageQty = new Random((int)DateTime.Now.Ticks).Next(10),
                QtyOnHand = new Random((int)DateTime.Now.Ticks).Next(10),
                Id = Guid.NewGuid(),
                ToShip = false
            });

            FillItems();
        }

        private void FillItems()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            foreach(var i in _im.GetInventoryList())
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
            }

            try
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }

            label3.Text = $"Inventory Count: {_im.GetInventoryCount()}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _im.Display(true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _im.Remove(((ItemObj)comboBox2.SelectedItem).Id);

            FillItems();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                // get search list
                var qty = int.Parse(textBox1.Text);
                //var dmg = checkBox1.Checked;

                var l = _im.Search(qty);

                _im.Display(true, l);

            }
            catch (Exception)
            {
                MessageBox.Show("Nothing to display");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var i = int.Parse(textBox2.Text);
                var id = ((ItemObj)comboBox1.SelectedItem).Id;
                _im.ReStock(i, id);

                FillItems();

            }
            catch (Exception)
            {
            }
        }
    }
}
