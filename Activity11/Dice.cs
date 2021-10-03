using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity11
{
    public class Dice
    {
        private int _sides = 6;

        public Dice(int sides)
        {
            if (sides < 4)
                throw new Exception("Minimum 4");

            if (sides > 20)
                throw new Exception("Max 20");

            _sides = sides;
        }

        public int rollDie()
        {
            return new Random((int)DateTime.Now.Ticks).Next(4, _sides) + 1;
        }
    }
}
