using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity10
{
    class Program
    {
        static void Main(string[] args)
        {
            UnionInts(new[] { 1, 3, 5 }, new[] { 1, 2, 3, 4, 5, 6 }).ToList().ForEach(c => Console.WriteLine(c.ToString()));
            Console.ReadKey();
        }


        static int[] UnionInts(int[] a, int[] b)
        {
            var t = a.Union(b);
            return t.ToArray();
        }
    }
}
