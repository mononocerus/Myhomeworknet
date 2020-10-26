using System;
using System.Collections.Generic;
using System.Text;

namespace homework2_1
{
    public class Triangle : shape
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }

    
        public override void Init()
        {
            string s = "";
            Console.WriteLine("PLEASE ENTER THE FIRST SIDE:");
            s = Console.ReadLine();
            Side1 = double.Parse(s);
            Console.WriteLine("PLEASE ENTER TEH SECOND SIDE ");
            s = Console.ReadLine();
            Side2 = double.Parse(s);
            Console.WriteLine("PLEASE ENTER THE THIRD SIDE");
            s = Console.ReadLine();
            Side3 = double.Parse(s);
        }
        public Triangle(double Side1, double Side2, double Side3)
        {
            this.Side1 = Side1;
            this.Side2 = Side2;
            this.Side3 = Side3;
            Console.WriteLine(this.Judge);
            Console.WriteLine(this.Area);
        }

        public override double Area
        {
            get
            {
                if (!this.Judge) { return -1; }

                double p = (Side1 + Side2 + Side3) / 2;
                return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));      // 海伦公式
            }
        }

        public override bool Judge 
        {
            get
            {
                if (Side1 > 0 && Side2 > 0 && Side3 > 0 &&
                    Side1 + Side2 > Side3 &&
                    Side1 + Side3 > Side2 &&
                    Side2 + Side3 > Side1)
                {
                    return true;
                }
                return false;
            }
        }
        public Triangle()
        {
            this.Init();
            Console.WriteLine(this.Judge);
            Console.WriteLine(this.Area);
        }
    }
}
