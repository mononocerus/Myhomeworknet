using System;
using System.Collections.Generic;
using System.Text;

namespace homework2_2
{
    public class Triangle : shape
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }

    
        public override void Init()
        {
            Random random = new Random();
            do
            {
                this.Side1 = random.NextDouble() * 100;
                this.Side2 = random.NextDouble() * 100;
                this.Side3 = random.NextDouble() * 100;
            } while (!this.Judge);
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
                    Console.WriteLine(" Successfully created a triangle");
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
