using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity15
{
    public partial class ResultForm : Form
    {

        private int _num = 1;

        public ResultForm()
        {
            InitializeComponent();

            // some number
            _num = new Random((int)DateTime.Now.Ticks).Next(1, 1000);
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            label2.Text = _num.ToString();
        }
    }
}
