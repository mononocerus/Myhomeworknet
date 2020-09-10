using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classwork2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { };
            a = new int[100];
            for (int i = 0; i < 100; i++)
            {
                a[i] = i + 1;
            }
            for (int s = 2; s <= 100; s++)
                for (int i = 0; i < 100; i++)
                {
                    if (a[i] % s == 0 && a[i] != s) a[i] = 0;
                }
            for (int i = 0; i < 100; i++)
            {
                if (a[i] != 0 && a[i] != 1)
                {
                    Console.Write(a[i]);
                    Console.WriteLine();
                }
            }
        }
    }
}
