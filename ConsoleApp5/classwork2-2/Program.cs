using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classwork2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 8, 32, 45, 11, 24, 100, 42, 32 };
            int s = a[0];
            for (int i = 0; i < 8; i++)
            {
                if (s < a[i]) s = a[i];
            }
            Console.WriteLine("最小的数字是{0:G}", s);

            for (int i = 0; i < 8; i++)
            {
                if (s > a[i]) s = a[i];
            }
            Console.WriteLine("最大的数字是{0:G}", s);
            s = 0;
            for (int i = 0; i < 8; i++)
            {
                s += a[i];
            }
            Console.WriteLine("和是：{0:G}", s);
        }
    }
}
