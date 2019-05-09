using System;
using System.IO;

namespace FileLogger
{
    public class Logger
    {
        private const string _loggingPath = @"C:\Temp\RPNLog.log";

        private eLogLevel _setLogLevel;

        public Logger(eLogLevel logLevel)
        { _setLogLevel = logLevel; }

        public void Trace(string logString)
        { LogBase(eLogLevel.Trace, logString); }

        public void Debug(string logString)
        { LogBase(eLogLevel.Debug, logString); }

        public void Info(string logString)
        { LogBase(eLogLevel.Info, logString); }

        public void Warn(string logString)
        { LogBase(eLogLevel.Warn, logString); }

        public void Error(string logString)
        { LogBase(eLogLevel.Error, logString); }

        public void Fatal(string logString)
        { LogBase(eLogLevel.Fatal, logString); }

        private void LogBase(eLogLevel logLevel, string logString)
        {
            if (logLevel >= _setLogLevel)
            {
                using (var sw = File.AppendText(_loggingPath))
                { sw.WriteLine($"{DateTime.UtcNow} - {logLevel} :: {logString}"); }
            }
        }
    }
}
