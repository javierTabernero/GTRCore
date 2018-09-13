using Serilog;
using Serilog.Formatting.Json;
using System;
using System.IO;

namespace GTR.CrossCutting.Logging
{
    public class Logger : ILogger
    {
        private Serilog.ILogger Log { get; } = new LoggerConfiguration().WriteTo.File(new JsonFormatter(), Path.Combine("Logs", ".log"), rollingInterval: RollingInterval.Day).CreateLogger();

        public void Error(Exception exception)
        {
            Log.Error(exception, exception.Message);
        }

        public void Info(string message)
        {
            Log.Information(message);
        }
    }
}
