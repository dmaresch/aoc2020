using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Linq;

namespace AoC_2020.Days
{
    public class Day8
    {
        class Instruction
        {
            public static int acc = 0;
            public string inst;
            public int val;
            public int seen=0;
            public Instruction(string i)
            {
                var x = i.Split(" ");
                inst = x[0];
                if(inst != "nop")
                    val = int.Parse(x[1]);
            }
            public override string ToString()
            {
                if (val < 0)
                    return $"Instruction: {inst} {val}";
                else
                    return $"Instruction: {inst} +{val}";
            }
        }
        public void Start()
        {
            int index = 0;
            List<Instruction> instructions = new List<Instruction>();
            File.ReadAllLines("Inputs/Day8.txt").ToList().ForEach(v => 
            {
                instructions.Add(new Instruction(v));
            });
            for (int i = 0; i < instructions.Count; i++)
            {
                if (instructions[i].inst == "jmp")
                {
                    Console.WriteLine(i);
                    foreach (Instruction ins in instructions)
                        ins.seen = 0;
                    index = 0;
                    Instruction.acc = 0;
                    instructions[i].inst = "nop";
                    while (true)
                    {
                        if (index == instructions.Count) break;
                        Console.WriteLine($"{index}: {instructions[index]}");
                        if (instructions[index].seen == 1) break;
                        instructions[index].seen++;
                        switch (instructions[index].inst)
                        {
                            case "nop":
                                index++;
                                break;
                            case "acc":
                                Instruction.acc += instructions[index].val;
                                index++;
                                break;
                            case "jmp":
                                index += instructions[index].val;
                                break;
                        }
                    }
                    instructions[i].inst = "jmp";
                    if(index == instructions.Count)
                    {
                        break;
                    }
                }
            }/*
            while (true)
            {
                Console.WriteLine($"{index}: {instructions[index]}");
                if (instructions[index].seen == 1) break;
                instructions[index].seen++;
                switch (instructions[index].inst)
                {
                    case "nop":
                        index++;
                        break;
                    case "acc":
                        Instruction.acc += instructions[index].val;
                        index++;
                        break;
                    case "jmp":
                        index += instructions[index].val;
                        break;
                }
            }*/
            Console.WriteLine($"Acc: {Instruction.acc}");
            Console.ReadKey();
        }
    }
}
