using System;


namespace Financology.Logger
{
    public static class LogManager
    {
        private static SerilogAdapter _logAdapter = new SerilogAdapter();

        public static void LogMessage(string message, string type)
        {
            _logAdapter.LogMessage(message, type);
        }

    }
}
