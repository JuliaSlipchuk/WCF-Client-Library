using System;
using Library2;

namespace Library3
{
    public class Class3 : Class2
    {
        public double F3 (double x, double y)
        {
            double res3 = this.F2(x, y) * this.F2(x, y);
            return res3;
        }
    }
}
