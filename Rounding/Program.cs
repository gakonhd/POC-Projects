using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rounding
{
    class Program
    {
        static void Main(string[] args)
        {
            var check = true;
            while (check)
            {
                Console.WriteLine("Number to convert");
                var inp = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Select a rounding");
                Console.WriteLine("1 - Bankers Rounding - Default - To Even");
                Console.WriteLine("2 - Mathematical Rounding - AwayFromZero");
                Console.WriteLine("3 - Floating rounding - AwayFromZero");
                Console.WriteLine("4 - Parsing decimal to string and vice versa");

                var key = Console.ReadKey();
                Console.WriteLine();
                if (key.Key == ConsoleKey.D1)
                {
                    Console.WriteLine($@"Round ToEven of {inp}: {decimal.Round(inp, 2)}");
                    Console.ReadLine();
                }else if (key.Key == ConsoleKey.D2) 
                {
                    Console.WriteLine($@"Round AwayFromZero of {inp}: {decimal.Round(inp, 2, MidpointRounding.AwayFromZero)}");
                    Console.ReadLine();
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    var db = Convert.ToSingle(inp);
                    Console.WriteLine($@"Round AwayFromZero of {db} with Float: {Math.Round(db, 2, MidpointRounding.AwayFromZero)}");
                    Console.ReadLine();
                }
                else if (key.Key == ConsoleKey.D4)
                {
                    var val = 0m;
                    var db = inp.ToString(CultureInfo.InvariantCulture);
                    Console.WriteLine($@"Try parse to decimal: {decimal.TryParse(db,  out val)}");
                    Console.Write(val);
                    Console.ReadLine();
                }
                else
                {
                    check = false;
                }
            }
        }
    }
}
