using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace CodingExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string[] instructions = new string[] {
                "int x",
                "int y",
                "set x 10",
                "set y 20",
                "add x y",
                "sub y 5",
                "print x",
                "print y",
            };

            ExecuteInstructions(instructions);

            stopwatch.Stop();

            Console.WriteLine("Executed in {0}ms. Press any key to continue.", stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }

        static void ExecuteInstructions(string[] instructions)
        {
            Dictionary<string, int> memory = new Dictionary<string, int>();
            foreach (string instruction in instructions)
            {
                string[] args = instruction.Split(' ');
                switch (args[0])
                {
                    case "int":
                        {
                            if (args.Length == 2)
                            {
                                if (Regex.IsMatch(args[1], @"^[a-zA-Z]+$"))
                                {
                                    memory.Add(args[1], 0);
                                }
                            }
                        } break;
                    case "set":
                        {
                            if (args.Length == 3)
                            {
                                if (memory.ContainsKey(args[1]))
                                {
                                    int num;
                                    if (!int.TryParse(args[2], out num))
                                    {
                                        Console.WriteLine("{0} is not a valid integer to set.", args[2]);
                                    }
                                    memory[args[1]] = num;
                                }
                            }
                        } break;
                    case "add":
                        {
                            if (args.Length == 3)
                            {
                                if (memory.ContainsKey(args[1]))
                                {
                                    int newnum = 0;
                                    if (!int.TryParse(args[2], out newnum))
                                    {
                                        //pull the value from memory.
                                        if (memory.ContainsKey(args[2]))
                                        {
                                            newnum = memory[args[2]];
                                        }
                                        else
                                        {
                                            //our variable wasn't found in memory, so we can't actually do anything here, execution halted.
                                            Console.WriteLine("The variable {0} was not found.", args[2]);
                                        }
                                    }
                                    memory[args[1]] = (memory[args[1]] + newnum);
                                }
                            }
                        } break;
                    case "sub":
                        {
                            if (args.Length == 3)
                            {
                                if (memory.ContainsKey(args[1]))
                                {
                                    int newnum = 0;
                                    if (!int.TryParse(args[2], out newnum))
                                    {
                                        //pull the value from memory.
                                        if (memory.ContainsKey(args[2]))
                                        {
                                            newnum = memory[args[2]];
                                        }
                                        else
                                        {
                                            //our variable wasn't found in memory, so we can't actually do anything here, execution halted.
                                            Console.WriteLine("The variable {0} was not found.", args[2]);
                                        }
                                    }
                                    memory[args[1]] = (memory[args[1]] - newnum);
                                }
                            }
                        } break;
                    case "print":
                        {
                            if (args.Length == 2)
                            {
                                if (memory.ContainsKey(args[1]))
                                {
                                    Console.WriteLine(memory[args[1]]);
                                }
                                else
                                {
                                    Console.WriteLine("The variable {0} was not found.", args[1]);
                                }
                            }
                        } break;
                }
            }
        }
    }
}
