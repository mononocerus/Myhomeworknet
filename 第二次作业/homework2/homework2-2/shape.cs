using System;
using System.Collections.Generic;
using System.Text;

namespace homework2_2
{
    public abstract class shape
    {
        public abstract void Init();
        abstract public bool Judge { get; }
        abstract public double Area { get; }
    }
}
