using System;
using NLog.Config;

namespace NLog.Targets.TextWriter
{
    public static class NLogTextWriterHelpers
    {
        /// <summary>
        /// Initializes NLog to TextWriter at Information Log Level
        /// </summary>
        /// <param name="textWriter">The text writer to target</param>
        public static void ConfigureNLogToTextWriter(System.IO.TextWriter textWriter)
        {
            var loggingConfiguration = new LoggingConfiguration();

            ConfigureNLogToTextWriter(
                loggingConfiguration,
                textWriter,
                LogLevel.Info);

            NLog.LogManager.Configuration = loggingConfiguration;
        }

        /// <summary>
        /// Adds NLog TextWriter at Information Log Level to an existing NLog configuration
        /// </summary>
        /// <param name="loggingConfiguration">NLog configuration</param>
        /// <param name="textWriter">The text writer to target</param>
        public static void ConfigureNLogToTextWriter(
            LoggingConfiguration loggingConfiguration,
            System.IO.TextWriter textWriter)
        {
            ConfigureNLogToTextWriter(
                loggingConfiguration,
                textWriter,
                LogLevel.Info);
        }

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
            ConfigureLoggingRules(loggingConfiguration,
                textWriter,
                target => new LoggingRule(loggerNamePattern, minLevel, target));
        }

        private static void ConfigureNLogToTextWriter(
            LoggingConfiguration loggingConfiguration,
            System.IO.TextWriter textWriter,
            LogLevel minLevel,
            LogLevel maxLevel,
            string loggerNamePattern = "*")
        {
            ConfigureLoggingRules(loggingConfiguration,
                textWriter,
                target => new LoggingRule(loggerNamePattern, minLevel, maxLevel, target));
        }

        private static void ConfigureLoggingRules(
            LoggingConfiguration loggingConfiguration,
            System.IO.TextWriter textWriter,
            Func<TextWriterTarget, LoggingRule> loggingRuleFactoryFunc)
        {
            var webJobTarget = new TextWriterTarget(textWriter);
            loggingConfiguration.AddTarget("TextWriter", webJobTarget);

            var loggingRule = loggingRuleFactoryFunc(webJobTarget);
            loggingConfiguration.LoggingRules.Add(loggingRule);

            NLog.LogManager.GetCurrentClassLogger().Debug("Hooked NLog to TextWriter stream.");
        }
    }
}