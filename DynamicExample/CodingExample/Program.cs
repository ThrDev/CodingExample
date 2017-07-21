using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace CodingExample
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

            Machine m = new Machine();

            m.Run(instructions);

            stopwatch.Stop();

            Console.WriteLine("Executed in {0}ms. Press any key to continue.", stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
