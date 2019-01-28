using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace sampleNoChecking
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] != null) {
                string path = AppDomain.CurrentDomain.BaseDirectory + "currentSample.txt";
                File.WriteAllText(path, args[0]);
            }
        }
    }
}
