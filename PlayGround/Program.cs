using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround
{
    class Program
    {
        static void Main(string[] args)
        {
            var loop = new LoopValidation();
            loop.DoValidate(true);
            Console.ReadKey();
        }
    }
}
