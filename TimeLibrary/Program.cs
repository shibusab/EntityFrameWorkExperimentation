﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = new TestTimeInterval();
            results.Check();
           Console.WriteLine( results.TestResults);
            Console.ReadKey();
        }
    }
}
