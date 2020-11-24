using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Class_Library
{
    public class FilePrinter : IPrinter
    {
        string outputFileName;
        public FilePrinter() : this("")
        {

        }
        public FilePrinter(string outputFileName)
        {
            this.outputFileName = outputFileName;
        }
        public void Print(string text)
        {
            using(StreamWriter streamwriter = new StreamWriter(outputFileName))
            {
                streamwriter.WriteLine(text);
            }
        }
    }
}
