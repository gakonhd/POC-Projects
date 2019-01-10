using System;

namespace POC_KMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var ex = new KMapExamples();
            ex.PrintOutTruthTable(ex.SetupTruthTable());

            var qty = 10;
            var original = 10;
            var final = 30;

            //var greatestUcd = Convert.ToInt32(UCD(Convert.ToUInt64(original), Convert.ToUInt64(final)));
            //var mod = (original / greatestUcd) % (final / greatestUcd);
            //var roundUp = 0;
            //if (mod >= final / (greatestUcd* 2.0))
            //{
            //    roundUp = 1;
            //}

            var division = Convert.ToDecimal(original) / Convert.ToDecimal(final);
            var res = Convert.ToInt32(division * qty);

            Console.Write(res);
            Console.Read();
        }

        public static ulong UCD(ulong a, ulong b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }
    }
}
