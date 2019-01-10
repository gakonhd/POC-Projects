using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround
{
    public class LoopValidation
    {
        //we have a sequence of condition needs validating
        public bool DoValidate(bool res)
        {
            var finalres = true;
            var something = new List<Action<int, int>>();
            something.Add((a, b) =>
            {
                finalres = a > b;
                Console.WriteLine("More is checked");
            });
            something.Add((a, b) =>
            {
                finalres = a < b;
                Console.WriteLine("Less is checked");
            });
            something.Add((a, b) =>
            {
                finalres = a == b;
                Console.WriteLine("Equal is checked");
            });
            var counter = 0;

            while (finalres && counter < something.Count)
            {
                something[counter++](5, 1);
            }
            Console.WriteLine(counter);
            return res;
        }

        public bool ValidateMore(int a, int b) => a > b;
        public bool ValidateLess(int a, int b) => a < b;
        public bool ValidateEqual(int a, int b) => a == b;


    }
}
