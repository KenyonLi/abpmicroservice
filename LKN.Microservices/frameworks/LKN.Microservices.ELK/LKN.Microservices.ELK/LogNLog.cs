using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKN.Microservices.ELK
{
    public class LogNLog : ILog
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LogNLog()
        {
        }

        public void Debug(string message)
        {
            Logger logger = LogManager.GetLogger("RmqTarget");
            var logEventInfo = new LogEventInfo(LogLevel.Debug, "RmqLogMessage", $"{message}, generated at {DateTime.UtcNow}.");
            logger.Log(logEventInfo);
            //LogManager.Shutdown();  
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Information(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }
    }
}
