using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classwork2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("输入一个数字");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    int s;
                    for (s = 2; s < i; s++)
                    {
                        if (i % s == 0)
                            s = i + 1;
                    }
                    if (s == i)
                    {
                        Console.Write(i);
                        Console.WriteLine("是素因素");
                    }
                }

            }
        }
    }
}
