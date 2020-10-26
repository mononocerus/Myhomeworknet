using System;
using homework2_2;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2_2
{
    class program
    {
       
            static void Main(string[] args)
            {
                Factory factory = new Factory();
                List<shape> shapeList = new List<shape>();

                for (int i = 0; i < 10; i++)
                {
                    shapeList.Add(factory.GetRandomShape());
                }
               

            }
        
    }
}
