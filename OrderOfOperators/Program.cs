using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderOfOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = FirstMethod() && SecondMethod() || ThirdMethod();
            Console.WriteLine(res);
            Console.ReadLine();
        }

        private static bool FirstMethod()
        {
            Console.WriteLine("This calls 1");
            return false;
        }

        private static bool SecondMethod()
        {
            Console.WriteLine("This calls 2");
            return true;
        }

        private static bool ThirdMethod()
        {
            Console.WriteLine("This calls 3");
            return true;
        }
    }
}
