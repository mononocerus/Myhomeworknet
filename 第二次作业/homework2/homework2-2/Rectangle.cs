using System;
using System.Collections.Generic;
using System.Text;

namespace homework2_2
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
                    Console.WriteLine("Successfully created a rectangle");
                    return true;
                }
                return false;
            }
        }
        public override void Init()
        {
            Random random = new Random();
            do
            {
                this.Length = random.NextDouble() * 100;
                this.Width = random.NextDouble() * 100;
            } while (!this.Judge);
        }
    

        public override double Area
        {
            get
            {
                if (!this.Judge) { return -1; }

                return Length * Width;
            }
        }

       
         public  Rectangle()
        {
            this.Init();
            Console.WriteLine(this.Judge);
            Console.WriteLine(this.Area);
        }
    }
}
