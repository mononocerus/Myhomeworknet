using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix;
            int x, y;
            matrix = new int[100,100];
            void makeamatrix()
            {
                Console.WriteLine("输入数组的长度");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("输入数组的宽度");
                y = Convert.ToInt32(Console.ReadLine());
                for(int a=0;a<x;a++)
                {
                    for(int b=0;b<y;b++)
                    {
                        Console.WriteLine("请输入：");
                        matrix[a, b] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("换行了");
                }
            }
            void isToeplitzMatrix()
            {
                int p=1;
                for(int i=1;i<x;i++)
                {
                    for(int n=1;n<y;n++)
                    {
                        if (matrix[i, n] == matrix[i - 1, n - 1]) ;
                        else p = 0;
                    }
                }
                if (p == 1) Console.WriteLine("是");
                else Console.WriteLine("不是");
            }
            makeamatrix();
            isToeplitzMatrix();
        }
    }
}
