using System;
using System.Collections.Generic;
using System.Text;
namespace homework2_2
{
    class Factory
    {
        private Random random = new Random();           // 避免Random在循环中生成

        
        public shape GetRandomShape()
        {

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int shapes = rand.Next(3);
            switch (shapes)
            {
                case 0:
                    return new Rectangle();
                case 1:
                    return new Square();
                case 2:
                    return new Triangle();
                default:
                    return null;
            }
        }
    }
}
