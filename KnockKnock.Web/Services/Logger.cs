using System;
using System.Diagnostics;

namespace KnockKnock.Web.Services
{
    /// <summary>
    /// The Logges singletone class
    /// </summary>
    public class Logger
    {
        private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());
        private Logger() {}
        public static Logger Instance => instance.Value;

        /// <summary>
        /// Log exceptions
        /// </summary>
        /// <param name="exToLog">Exception to log</param>
        /// <returns>Logged exception</returns>
        public Exception LogError(Exception exToLog)
        {
#if DEBUG
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
#endif

            // TODO: log

            return exToLog;
        }
    }
}