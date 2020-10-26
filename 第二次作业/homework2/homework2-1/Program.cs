using System;

namespace homework2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(4, 3); //第一种产生方形的方式
            Triangle tri = new Triangle(5, 7, 8); //第一种产生三角形的方式

            Triangle tri2 = new Triangle(); //第二种产生三角形的方式（通过键盘输入）
            Rectangle rect2 = new Rectangle(); //第二种产生方形的方式（通过键盘输入）
        }
    }
}
