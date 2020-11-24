using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
