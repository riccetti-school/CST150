using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity13
{
    public partial class Form1 : Form
    {
        int[,] _grid = new int[3, 3];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CleanGrid();

        }

        private void CleanGrid()
        {
            label1.Text = string.Empty;
            label2.Text = string.Empty;
            label3.Text = string.Empty;
            label4.Text = string.Empty;
            label5.Text = string.Empty;
            label6.Text = string.Empty;
            label7.Text = string.Empty;
            label8.Text = string.Empty;
            label9.Text = string.Empty;

            for (int i = 0; i < _grid.GetLength(0); i++)
                for (int o = 0; o < _grid.GetLength(1); o++)
                    _grid[i, o] = -1;
        }

        /// <summary>
        /// main game logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // clean the grid first
            CleanGrid();

            // run the game
            RunGame();
        }

        private void RunGame()
        {
            var endGame = false;
            var player = 1;
            while (!endGame)
            {
                SetObject(player);

                DrawGrid();

                if(player == 1)
                {
                    player = 2;
                }
                else
                {
                    player = 1;
                }

                endGame = CheckEnd();
            }

            CheckWon();
        }

        private void CheckWon()
        {
            var row1 = _grid[0, 0] + _grid[1, 0] + _grid[2, 0];
            var row2 = _grid[0, 1] + _grid[1, 1] + _grid[2, 1];
            var row3 = _grid[0, 2] + _grid[1, 2] + _grid[2, 2];

            var col1 = _grid[0, 0] + _grid[0, 1] + _grid[0, 2];
            var col2 = _grid[1, 0] + _grid[1, 1] + _grid[1, 2];
            var col3 = _grid[2, 0] + _grid[2, 1] + _grid[2, 2];

            var diag1 = _grid[0, 0] + _grid[1, 1] + _grid[2, 2];
            var diag2 = _grid[0, 2] + _grid[1, 1] + _grid[2, 0];

            if(diag1 == 3)
            {
                MessageBox.Show("Player 1 WON!!!!");
                return;
            }

            if(diag2 == 3)
            {
                MessageBox.Show("Player 1 WON!!!!");
                return;
            }

            if(diag1 == 6)
            {
                MessageBox.Show("Player 2 WON!!!!");
                return;
            }

            if(diag2 == 6)
            {
                MessageBox.Show("Player 2 WON!!!!");
                return;
            }

            if (row1 == 3 || row2 == 3 || row3 == 3)
            {
                MessageBox.Show("Player 1 WON!!!!");
                return;
            }

            if (row1 == 6 || row2 == 6 || row3 == 6)
            { 
                MessageBox.Show("Player 2 WON!!!!");
                return;
            }


            if(col1 == 3 || col2 == 3 || col3 == 3)
            {
                MessageBox.Show("Player 1 WON!!!!");
                return;
            }

            if(col1 == 6 || col2 == 6 || col3 == 6)
            {
                MessageBox.Show("Player 2 WON!!!!");
                return;
            }

        }

        private void DrawGrid()
        {
            var i = 1;
            for (int y = 0; y < _grid.GetLength(1); y++)
                for (int x = 0; x < _grid.GetLength(0); x++)
                {

                    var xoro = _grid[x, y] == 1 ? "X" : "O";

                    switch (i)
                    {
                        case 1:
                            label1.Text = xoro;
                            break;
                        case 2:
                            label2.Text = xoro;
                            break;
                        case 3:
                            label3.Text = xoro;
                            break;
                        case 4:
                            label4.Text = xoro;
                            break;
                        case 5:
                            label5.Text = xoro;
                            break;
                        case 6:
                            label6.Text = xoro;
                            break;
                        case 7:
                            label7.Text = xoro;
                            break;
                        case 8:
                            label8.Text = xoro;
                            break;
                        case 9:
                            label9.Text = xoro;
                            break;

                    }


                    i++;

                }
        }

        private void SetObject(int player)
        {

            var spots = new List<Tuple<int, int>>();

            // get all the empty spots
            for (int y = 0; y < _grid.GetLength(0); y++)
                for (int x = 0; x < _grid.GetLength(1); x++)
                {
                    if (_grid[x, y] == -1)
                        spots.Add(new Tuple<int, int>(x, y));
                }

            var l = spots.Count();

            // get random spot
            var spot = spots.ToArray()[new Random().Next(l)];

            _grid[spot.Item1, spot.Item2] = player;
        }

        private bool CheckEnd()
        {
            for (int y = 0; y < _grid.GetLength(0); y++)
                for (int x = 0; x < _grid.GetLength(1); x++)
                    if (_grid[x, y] == -1) return false;

            return true;
        }
    }
}
