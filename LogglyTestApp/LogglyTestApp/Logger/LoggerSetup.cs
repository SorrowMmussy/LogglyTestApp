using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.loggly;
using log4net.Repository.Hierarchy;

namespace LogglyTestApp.Logger
{
    public class LoggerSetup
    {
        //Useful but not necessary to read:
        //https://stackoverflow.com/questions/594298/c-sharp-dll-config-file
        //https://stackoverflow.com/questions/16336917/can-you-configure-log4net-in-code-instead-of-using-a-config-file
        public void Setup()
        {
            log4net.Util.LogLog.InternalDebugging = true;

            var hierarchy = (Hierarchy)LogManager.GetRepository();
            hierarchy.Root.RemoveAllAppenders();
            var logglyAppender = new LogglyAppender
            {
                Name = "logglyAppender",
                RootUrl = "https://logs-01.loggly.com/",
                CustomerToken = "113815c4-4eb1-48b1-90a6-96d28f651626",
                Tag = "log4net",
                Threshold = Level.All,
            };

            hierarchy.Root.AddAppender(logglyAppender);

            ConfigLogger("loggly", logglyAppender, Level.All);
            hierarchy.Root.Level = Level.All;
            hierarchy.Configured = true;
        }

        private void ConfigLogger(string loggerName, IAppender appender, Level level)
        {
            level = level ?? Level.All;
            var log = LogManager.GetLogger(loggerName);
            var logger = (log4net.Repository.Hierarchy.Logger)log.Logger;
            logger.Level = level;
            logger.AddAppender(appender);
        }
    }
}
