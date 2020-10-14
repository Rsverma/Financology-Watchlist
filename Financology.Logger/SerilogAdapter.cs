using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace Financology.Logger
{
    class SerilogAdapter
    {
        internal SerilogAdapter()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("", rollingInterval: RollingInterval.Month).CreateLogger();
        }
        internal void LogMessage(string message, string Type)
        {
            Log.Information(message);
        }
    }
}
