using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExample
{
    class Machine
    {
        private Interpreter interpreter;
        private Dictionary<string,int> memory;

        public Machine()
        {
            this.interpreter = new Interpreter();
            this.memory = new Dictionary<string, int>();
        }

        public bool Run(string[] instructions)
        {
            foreach (string instruction in instructions)
            {
                bool output = this.interpreter.DoInstruction(instruction, this.memory);
                if (!output)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
