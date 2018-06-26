using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JobAutomation
{
    public static class LogManager
    {
        public static void WriteLog(string text)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
            File.AppendAllText(path, DateTime.Now + ": " + text);
        }
    }
}
