using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Linq;

namespace AoC_2020.Days
{
    public class Day6
    {
        public void Start()
        {
            int total = 0;
            int totalp2 = 0;
            List<string> inp = File.ReadAllText("Inputs/Day6.txt").Split("\r\n\r\n").ToList();
            foreach(string i in inp)
            {
                //List<char> seen = new List<char>();
                Dictionary<char, int> seen = new Dictionary<char, int>();
                int inst = i.Split("\r\n").Length;
                foreach(char c in i)
                {
                    if (!seen.ContainsKey(c) && c != '\n' && c != '\r') seen.Add(c, 1);
                    if (c != '\n' && c != '\r') seen[c]++;
                }
                foreach (char key in seen.Keys)
                {
                    if (seen[key] == inst + 1) totalp2++;
                }
                total += seen.Keys.Count();
            }
            Console.WriteLine(total);
            Console.WriteLine(totalp2);
            Console.ReadKey();
        }
    }
}
