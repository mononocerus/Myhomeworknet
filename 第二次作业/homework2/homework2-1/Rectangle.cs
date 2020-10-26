using System;
using System.Collections.Generic;
using System.Text;

namespace homework2_1
{
    public class Rectangle : shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public override bool Judge 
        {
            get
            {
                if (Length > 0 && Width > 0)
                {
                    return true;
                }
                return false;
            }
        }
        public override void Init()
        {
            string s = "";
            Console.WriteLine("PLEASE ENTER THE LENGTH:");
            s = Console.ReadLine();
            Length = double.Parse(s);
            Console.WriteLine("PLEASE ENTER THE WIDTH:");
            s = Console.ReadLine();
            Width = double.Parse(s);
        }
    

        public override double Area
        {
            get
            {
                if (!this.Judge) { return -1; }

                return Length * Width;
            }
        }

        public Rectangle(double Length, double Width)
        {
            this.Length = Length;
            this.Width = Width;
            Console.WriteLine(this.Judge);
            Console.WriteLine(this.Area);
        }
         public  Rectangle()
        {
            this.Init();
            Console.WriteLine(this.Judge);
            Console.WriteLine(this.Area);
        }
    }
}
