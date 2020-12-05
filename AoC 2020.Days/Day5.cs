using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Linq;

namespace AoC_2020.Days
{
    public class Day5
    {
        int highestSeatId;
        public void Start()
        {
            List<string> passes = File.ReadAllLines("Inputs/Day5.txt").ToList();
            passes.ForEach(pass =>
            {
                int r = ParseRow(pass.Substring(0, 7));
                int c = ParseColumn(pass.Substring(7));
                int combo = r * 8 + c;
                Console.WriteLine($"{r} {c} {combo}");
                if (highestSeatId < combo) highestSeatId = combo;
            });
            Console.WriteLine(highestSeatId);
            Console.ReadKey();
        }
        public int ParseRow(string row)
        {
            int min = 0;
            int max = 127;
            foreach (char c in row.ToLower())
            {
                int m = min + (max - min) / 2;
                if (c == 'b') min = m + 1;
                if (c == 'f') max = m;
            }
            return row[6] == 'B' ? max : min;
        }
        public int ParseColumn(string col)
        {
            int min = 0;
            int max = 7;
            foreach(char c in col.ToLower())
            {
                int m = min + (max - min) / 2;
                if (c == 'r') min = m + 1;
                if (c == 'l') max = m;
            }
            return col[2] == 'R' ? max : min;
        }
    }
}
