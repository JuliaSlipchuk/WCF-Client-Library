using System;
using Library2;

namespace Library4
{
    public class Class4
    {
        public static double F4 (double x, double y)
        {
            Class2 obj2 = new Class2();
            double re4 = 4 * obj2.F2(x, y) - 3;
            return re4;
        }
    }
}
