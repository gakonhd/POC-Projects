using System;
using System.Collections.Generic;
using System.Linq;

namespace POC_KMap
{
    public class KMapExamples
    {
        public bool A { get; set; }
        public bool B { get; set; }
        public bool C { get; set; }

        public bool Result()
        {
            return (!A && !B && !C) || (!A && B && C) || (!A && B && !C) || (A && B && !C) || (A && C && B) || (A && C && !B);
        }

        public bool KmapResult()
        {
            return B || A & C || !A & !C;
        }


        public IEnumerable<Tuple<int, int, int>> SetupTruthTable()
        {
            return new[]
            {
                new Tuple<int, int, int>(0, 0, 0),
                new Tuple<int, int, int>(0, 1, 0),
                new Tuple<int, int, int>(0, 1, 1),
                new Tuple<int, int, int>(1, 0, 1),
                new Tuple<int, int, int>(1, 1, 0),
                new Tuple<int, int, int>(1, 1, 1)
            };
        }

        public void PrintOutTruthTable(IEnumerable<Tuple<int, int, int>> conditions)
        {
            var truth = new[]
            {
                new[]{0, 0, 0, 0},
                new[]{0, 0, 1, 0},
                new[]{0, 1, 0, 0},
                new[]{0, 1, 1, 0},
                new[]{1, 0, 0, 0},
                new[]{1, 0, 1, 0},
                new[]{1, 1, 0, 0},
                new[]{1, 1, 1, 0 }
            };

            for (var i = 0; i < truth.Length; i++)
            {
                for (var j = 0; j < conditions?.ToArray().Length; j++)
                {
                    if (truth[i][0].Equals(conditions.ToArray()[j].Item1) &&
                        truth[i][1].Equals(conditions.ToArray()[j].Item2) &&
                        truth[i][2].Equals(conditions.ToArray()[j].Item3))
                    {
                        truth[i][truth[i].Length - 1] = 1;
                    }
                }
                Console.WriteLine($"{truth[i][0]} {truth[i][1]} {truth[i][2]} || {truth[i][3]}");
            }
        }

        private int Pow(int n)
        {
            if (n == 1) return 2;
            return 2 * Pow(n - 1);
        }
    }
}
