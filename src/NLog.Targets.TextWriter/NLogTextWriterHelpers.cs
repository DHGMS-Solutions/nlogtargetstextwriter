using NLog.Config;

namespace NLog.Targets.TextWriter
{
    public static class NLogTextWriterHelpers
    {
        public static void ConfigureNLogToTextWriter(
            System.IO.TextWriter textWriter,
            LogLevel minLevel,
            string loggerNamePattern = "*")
        {
            var loggingConfiguration = new LoggingConfiguration();

            ConfigureNLogToTextWriter(
                loggingConfiguration,
                textWriter,
                minLevel,
                loggerNamePattern);

            NLog.LogManager.Configuration = loggingConfiguration;
        }

        public static void ConfigureNLogToTextWriter(
            System.IO.TextWriter textWriter,
            LogLevel minLevel,
            LogLevel maxLevel,
            string loggerNamePattern = "*")
        {
            var loggingConfiguration = new LoggingConfiguration();
            ConfigureNLogToTextWriter(
                loggingConfiguration,
                textWriter,
                minLevel,
                maxLevel,
                loggerNamePattern);

            NLog.LogManager.Configuration = loggingConfiguration;
        }

        private static void ConfigureNLogToTextWriter(
            LoggingConfiguration loggingConfiguration,
            System.IO.TextWriter textWriter,
            LogLevel minLevel,
            string loggerNamePattern = "*")
        {
            var webJobTarget = new TextWriterTarget(textWriter);
            loggingConfiguration.AddTarget("TextWriter", webJobTarget);

            var loggingRule = new LoggingRule(loggerNamePattern, minLevel, webJobTarget);
            loggingConfiguration.LoggingRules.Add(loggingRule);

            WriteInitMessage();
        }

        private static void ConfigureNLogToTextWriter(
            LoggingConfiguration loggingConfiguration,
            System.IO.TextWriter textWriter,
            LogLevel minLevel,
            LogLevel maxLevel,
            string loggerNamePattern = "*")
        {
            var webJobTarget = new TextWriterTarget(textWriter);
            loggingConfiguration.AddTarget("TextWriter", webJobTarget);

            var loggingRule = new LoggingRule(loggerNamePattern, minLevel, maxLevel, webJobTarget);
            loggingConfiguration.LoggingRules.Add(loggingRule);

            WriteInitMessage();
        }

        private static void WriteInitMessage()
        {
            NLog.LogManager.GetCurrentClassLogger().Debug("Hooked NLog to TextWriter stream.");
        }
    }
}