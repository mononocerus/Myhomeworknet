using System;
using System.Collections.Generic;
using System.Text;

namespace homework2_1
{
    public class Square : Rectangle
    {
        public double Side
        {
            set
            {
                this.Length = value;
                this.Width = value;
            }
        }

        public Square() : base()
        {
            this.Width = this.Length;
        }

        public Square(double side) : base(side, side) { }
    }
}
