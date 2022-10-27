using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Assignment_2.Interfaces;

namespace SWT_Assignment_2
{
    public class LogFile:ILogFile
    {

        private readonly string logFile_;
        public LogFile( string logFile="logfile.txt")
        {
            logFile_ = logFile;
        }
        public void log(string writeToLogFile)
        {
            using (var writer = File.AppendText(logFile_))
            {
                writer.WriteLine($"{DateTime.Now}: {writeToLogFile}");
            }
        }
    }
}
