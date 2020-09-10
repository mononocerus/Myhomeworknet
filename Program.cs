using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classwork1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, answer = 0;
            string c;
            Console.WriteLine("请输入第一个数字：");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入运算符号：");
            c = Console.ReadLine();
            Console.WriteLine("请输入第二个数字：");
            b = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case "+": answer = a + b; break;
                case "-": answer = a - b; break;
                case "*": answer = a * b; break;
                case "/": answer = a / b; break;
            }
            Console.WriteLine("答案是:{0 :G}", answer);
        }
    }
}
