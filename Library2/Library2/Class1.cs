using System;
using Library1;

namespace Library2
{
    public class Class2
    {
        public double F2 (double x, double y)
        {
            double res2 = 2 * Library1.Class1.F1(x, y) + 5;
            return res2;
        }
    }
}
