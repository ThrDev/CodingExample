using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExample
{
    class Instruction
    {
        private string opcode;
        private List<string> args;

        public Instruction(string instruction)
        {
            this.args = new List<string>();

            string[] instructionsplit = instruction.Split(' ');
            //here we assume that the opcode is the first in the instruction.
            //also do any checking for alphanumeric stuff here.
            opcode = instructionsplit[0];
            //the rest are arguments.
            for(int i = 1; i < instructionsplit.Length; i++) {
                this.args.Add(instructionsplit[i]);
            }
        }

        public string OpCode
        {
            get
            {
                return this.opcode;
            }
        }

        public List<string> Args
        {
            get
            {
                return this.args;
            }
        }
    }
}
