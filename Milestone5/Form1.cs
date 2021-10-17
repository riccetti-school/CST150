using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone5
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
                System.Threading.Thread.Yield();
                label3.Text = $"Inventory Count: {_im.GetInventoryCount()}";
                label3.Refresh();
            }

            try
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _im.Display(true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = string.Empty;
            label4.Text = string.Empty;
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

                if(sender != null)
                    _im.Display(true, l);
                else
                    _im.Display(false, l);

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

        private void L(string inData)
        {
            //label4.Text = string.Empty;
            label4.Text = inData;
            label4.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            L("Starting stress test....");
            System.Threading.Thread.Sleep(3000);
            L("Adding a random number of inventory items...");
            var i = new Random((int)DateTime.Now.Ticks).Next(100);
            for (int y = 0; y < i; y++)
            {
                button2_Click(null, null);
                System.Threading.Thread.Yield();
            }

            L("Removing items...");
            var it = comboBox2.Items.Count;
            var rt = new Random((int)DateTime.Now.Ticks).Next(it); ;
            for(int x=0;x<rt;x++)
            {
                button3_Click(null, null);
                System.Threading.Thread.Yield();
            }

            L("Display the items int he debug window...");
            _im.Display();

            L("Multi-Searching....");
            var g = new Random((int)DateTime.Now.Ticks).Next(100);
            for(int h=0;h<g;h++)
            {
                var f = new Random((int)DateTime.Now.Ticks).Next(10);
                textBox1.Text = f.ToString();
                button5_Click(null, null);
                System.Threading.Thread.Yield();
            }

            L("Restocking.....");
            g = new Random((int)DateTime.Now.Ticks).Next(100);
            for (int h = 0; h < g; h++)
            {
                var f = new Random((int)DateTime.Now.Ticks).Next(10);
                textBox2.Text = f.ToString();
                button6_Click(null, null);
                System.Threading.Thread.Yield();
            }
        }
    }
}
