using System;
using System.Net.Http;
using System.Web;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AoC_2020
{
    class Day2
    {
        class Policy
        {
            public int minTimes { get; set; }
            public int maxTimes { get; set; }
            public char charToMatch { get; set; }
            public string password { get; set; }
            public bool valid1 { get => IsValidPart1(); }
            public bool valid2 { get => IsValidPart2(); }
            public int instances { get; set; }
            

            public Policy(string line)
            {
                string[] parts = line.Split(" ");
                minTimes = Convert.ToInt32(parts[0].Split("-")[0]);
                maxTimes = Convert.ToInt32(parts[0].Split("-")[1]);
                charToMatch = parts[1][0];
                password = parts[2];
                password.ToList().ForEach(x => { if (x == charToMatch) instances++; });
            }
            private bool IsValidPart1()
            {
                if (instances > maxTimes) return false;
                if (instances < minTimes) return false;
                return true;
            }
            private bool IsValidPart2()
            {
                int bad = 0;
                if (password[minTimes - 1] == charToMatch) bad++;
                if (password[maxTimes - 1] == charToMatch) bad++;
                if (bad == 0 || bad == 2) return false;
                return true;
            }
        }
        static void Main(string[] args)
        {
            new Day2().Start();
        }

        void Start()
        {
            List<Policy> passes = new List<Policy>();
            File.ReadAllLines("Inputs/Day2.txt").ToList().ForEach(x => passes.Add(new Policy(x)));
            int inst1 = 0;
            int inst2 = 0;
            passes.ForEach(x =>
            {
                if (x.valid1) inst1++;
                if (x.valid2) inst2++;
            });
            Console.WriteLine(inst1);
            Console.WriteLine(inst2);
            Console.ReadKey();
        }
    }
}