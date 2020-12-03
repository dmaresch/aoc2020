using System;
using System.Net.Http;
using System.Web;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AoC_2020
{
    class Day1
    {
        static void Main(string[] args)
        {
            new Day1().Start();
        }

        void Start()
        {
            List<int> x = new List<int>();
            File.ReadAllLines("Inputs/Day1.txt").ToList().ForEach(elem => x.Add(Convert.ToInt32(elem)));

            /* Part 1 */
            x.ForEach(elem =>
            {
                x.ForEach(elem2 =>
                {
                    if (elem + elem2 == 2020)
                    {
                        Console.WriteLine($"{elem},{elem2}");
                        Console.WriteLine(elem * elem2);
                    }
                });
            });

            /* Part 2 */
            x.ForEach(elem =>
            {
                x.ForEach(elem2 =>
                {
                    x.ForEach(elem3 =>
                    {
                        if (elem + elem2 + elem3 == 2020)
                        {
                            Console.WriteLine($"{elem},{elem2},{elem3}");
                            Console.WriteLine(elem * elem2 * elem3);
                        }
                    });
                });
            });

            Console.ReadKey();
        }
    }
}
