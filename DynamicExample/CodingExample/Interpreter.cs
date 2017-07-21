using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodingExample
{
    class Interpreter
    {
        private Dictionary<string, Delegate> OpCodes;

        public Interpreter()
        {
            this.OpCodes = new Dictionary<string, Delegate>()
            {
                { "int",  new Func<List<string>, Dictionary<string, int>, bool>(delegate(List<string> args, Dictionary<string, int> memory) {
                    //set a new variable.
                    if (Regex.IsMatch(args[0], @"^[a-zA-Z]+$")) { 
                        memory.Add(args[0], 0);
                        return true;
                    }
                    return false;
                }) },
                { "set",  new Func<List<string>, Dictionary<string, int>, bool>(delegate(List<string> args, Dictionary<string, int> memory) {
                    if (memory.ContainsKey(args[0]))
                    {
                        int num;
                        if (!int.TryParse(args[1], out num))
                        {
                            return false;
                        }
                        memory[args[0]] = num;
                        return true;
                    }
                    return false;
                }) },
                { "add",  new Func<List<string>, Dictionary<string, int>, bool>(delegate(List<string> args, Dictionary<string, int> memory) {
                    if (memory.ContainsKey(args[0]))
                    {
                        int newnum = 0;
                        if (!int.TryParse(args[1], out newnum))
                        {
                            //pull the value from memory.
                            if (memory.ContainsKey(args[1]))
                            {
                                newnum = memory[args[1]];
                            }
                            else
                            {
                                //our variable wasn't found in memory, so we can't actually do anything here, execution halted.
                                return false;
                            }
                        }

                        memory[args[0]] = (memory[args[0]] + newnum);
                        return true;
                    }
                    return false;
                }) },
                { "sub", new Func<List<string>, Dictionary<string, int>, bool>(delegate(List<string> args, Dictionary<string, int> memory) { 
                    if (memory.ContainsKey(args[0]))
                    {
                        int newnum = 0;
                        if (!int.TryParse(args[1], out newnum))
                        {
                            //pull the value from memory.
                            if (memory.ContainsKey(args[1]))
                            {
                                newnum = memory[args[1]];
                            }
                            else
                            {
                                //our variable wasn't found in memory, so we can't actually do anything here, execution halted.
                                return false;
                            }
                        }

                        memory[args[0]] = (memory[args[0]] - newnum);
                        return true;
                    }
                    return false;
                }) },
                { "print",  new Func<List<string>, Dictionary<string, int>, bool>(delegate(List<string> args, Dictionary<string, int> memory) { 
                    //access memory.
                    if(memory.ContainsKey(args[0])) {
                        Console.WriteLine(memory[args[0]]);
                        return true;
                    }
                    Console.WriteLine("The variable that you wanted to print was not previously declared.");
                    return false;
                }) },
            };
        }

        public bool DoInstruction(string input, Dictionary<string, int> memory)
        {
            Instruction inst = new Instruction(input);
            if(!this.OpCodes.ContainsKey(inst.OpCode)) {
                Console.WriteLine("The OpCode {0} was not found.", inst.OpCode);
            }
            return (bool)this.OpCodes[inst.OpCode].DynamicInvoke(inst.Args, memory);
        }
    }
}
