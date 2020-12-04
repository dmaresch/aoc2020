using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC_2020.Days
{
    public class Day4
    {
        List<Passport> passports = new List<Passport>();
        class Passport
        {
            /*
             * byr (Birth Year)
                iyr (Issue Year)
                eyr (Expiration Year)
                hgt (Height)
                hcl (Hair Color)
                ecl (Eye Color)
                pid (Passport ID)
                cid
            */
            public int byr;
            public int iyr;
            public int eyr;
            public string hgt;
            public string hcl;
            public string ecl;
            public long pid;
            public int cid;
            public bool valid;
            public Passport()
            {

            }
        }
        public void Start()
        {
            /*
             * byr (Birth Year) - four digits; at least 1920 and at most 2002.
                iyr (Issue Year) - four digits; at least 2010 and at most 2020.
                eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
                hgt (Height) - a number followed by either cm or in:
                If cm, the number must be at least 150 and at most 193.
                If in, the number must be at least 59 and at most 76.
                hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                pid (Passport ID) - a nine-digit number, including leading zeroes.
                cid (Country ID) - ignored, missing or not.
            */
            //8 values - bitshift
            int valid = 0;
            File.ReadAllText("Inputs/Day4.txt").Split("\r\n\r\n").ToList().ForEach(passport =>
            {
                byte validity = 0;
                passport.Replace('\n', ' ').Split(' ').ToList().ForEach(passVal =>
                {
                    if (passVal.Contains('\r')) passVal.Remove(passVal.Length - 1);
                    if (passVal.Split(':')[0] == "byr")
                    {
                        int v = Convert.ToInt32(passVal.Split(':')[1]);
                        if((v.ToString().Length == 4 && v <= 2002 && v >= 1920)) validity += 1 << 7;
                    }
                    if (passVal.Split(':')[0] == "iyr") 
                    {
                        int v = Convert.ToInt32(passVal.Split(':')[1]);
                        if((v.ToString().Length == 4 && v <= 2020 && v >= 2010)) validity += 1 << 6;
                    }
                    if (passVal.Split(':')[0] == "eyr")
                    {
                        int v = Convert.ToInt32(passVal.Split(':')[1]);
                        if((v.ToString().Length == 4 && v <= 2030 && v >= 2020)) validity += 1 << 5;
                    }
                    if (passVal.Split(':')[0] == "hgt") 
                    {
                        string v = passVal.Split(':')[1];
                        int val;
                        Int32.TryParse(v.Remove(v.IndexOf("cm") == -1 ? v.Length-1 : v.IndexOf("cm")), out val);
                        Int32.TryParse(v.Remove(v.IndexOf("in") == -1 ? v.Length-1 : v.IndexOf("in")), out val);
                        if (v.EndsWith("in") && val <= 76 && val >= 59) validity += 1 << 4;
                        if (v.EndsWith("cm") && val <= 193 && val >= 150) validity += 1 << 4;
                    }
                    if (passVal.Split(':')[0] == "hcl")
                    {
                        string v = passVal.Split(':')[1];
                        if(Regex.Match(v, "^#(?:[0-9a-fA-F]{3}){1,2}$").Success) 
                            validity += 1 << 3;
                    }
                    if (passVal.Split(':')[0] == "ecl")
                    {
                        List<string> validCol = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                        string v = passVal.Split(':')[1];
                        if( validCol.Contains(v)) 
                            validity += 1 << 2;
                    }
                    if (passVal.Split(':')[0] == "pid")
                    {
                        string v = passVal.Split(':')[1];
                        bool tp = Int32.TryParse(v, out _);
                        if (v.Length == 9 && tp) 
                            validity += 1 << 1;
                    }
                    if (passVal.Split(':')[0] == "cid") validity += 1;
                });
                if (validity == 254 || validity == 255) valid++;
            });
            Console.WriteLine(valid);
            Console.ReadKey();
        }
    }
}
