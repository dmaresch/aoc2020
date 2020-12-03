using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC_2020
{
    class Day3
    {
        class Map
        {
            int right_num { get; set; }
            int down_num { get; set; }
            int h_size { get; set; }
            List<string> fixedMap { get; set; }
            public int trees { get => CalcTrees(); }
            public Map(int r, int d)
            {
                List<string> x = File.ReadAllLines("Inputs/Day3.txt").ToList();
                fixedMap = new List<string>();
                down_num = d;
                right_num = r;
                h_size = x.Count * r;
                int mult = h_size / x[1].Count() + 1;
                x.ForEach(line => { fixedMap.Add(String.Concat(Enumerable.Repeat(line, mult))); });
            }
            private int CalcTrees()
            {
                int x_Pos = 0;
                int inst = 0;
                if (down_num == 1) {
                    fixedMap.ForEach(line =>
                    {
                        if(line[x_Pos] == '#') inst++;
                        x_Pos += right_num;
                    });
                }
                else
                {
                    for(int i = 0; i < fixedMap.Count; i+= down_num)
                    {
                        if (fixedMap[i][x_Pos] == '#') inst++;
                        x_Pos += right_num;
                    }
                }
                return inst;
            }
        }
        static void Main(string[] args)
        {
            new Day3().Start();
        }
        void Start()
        {
            //Down 1, Right 3
            List<Map> maps = new List<Map>();
            double x = 1;
            maps.Add(new Map(1, 1));
            maps.Add(new Map(3, 1));
            maps.Add(new Map(5, 1));
            maps.Add(new Map(7, 1));
            maps.Add(new Map(1, 2));
            maps.ForEach(m =>
            {
                Console.WriteLine($"Trees: {m.trees}");
                x *= m.trees;
            });
            Console.WriteLine($"Trees Total: {x}");
        }
    }
}