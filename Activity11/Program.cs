using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity11
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Dice(6).rollDie();
            System.Threading.Thread.Sleep(1000);
            var b = new Dice(6).rollDie();

            if (a == 1 && b == 1)
                Console.WriteLine("Snake eyes!!!!!");

            Console.WriteLine($"A: {a} - B: {b}");

            Console.ReadKey();
        }
    }
}
