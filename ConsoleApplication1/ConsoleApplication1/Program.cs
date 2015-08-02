using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        int _a = 2;

        static int b = 3;

        private delegate string GetAString();

        static void Main()
        {
            int s = 20;
            GetAString firstStringMethod = new GetAString(s.ToString);
            Console.WriteLine(firstStringMethod());
            Console.WriteLine(firstStringMethod.Invoke());
            sbyte o = 127;
            //checked { ++o; }
            ++o;
            Console.WriteLine(o);
            int r=9;
            Console.WriteLine(R(ref r));
            Console.WriteLine(DayOfWeek.Friday);
            Console.WriteLine(r);
            int z;
            Console.WriteLine("z+a=out "+ F(out z));
            const int n = 6;
            int c = 4;
            Program p = new Program();
            Console.WriteLine("gET tYPE: "+p.GetType(), p.MemberwiseClone());
            Console.WriteLine(p._a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(c.GetType());
            //Console.WriteLine(F());
            for(int i = 0; i < 3; i++)
            {
                int d = 5;
                Console.WriteLine(d);
            }
            //Console.ReadLine();
            return;
        }
        public static int R(ref int r)
        {
            r = 2;
            return r;
        }
        public static int F(out int z)
        {
            z = 2;
            int a = 5;
            return z + a;
        }
    }
}
