using System;
using NLog.Config;

namespace NLog.Targets.TextWriter
{
    public static class NLogTextWriterHelpers
    {
        /// <summary>
        /// Adds NLog TextWriter at Information Log Level to an existing NLog configuration
        /// </summary>
        /// <param name="loggingConfiguration">NLog configuration</param>
        /// <param name="textWriter">The text writer to target</param>
        public static void ConfigureNLogToTextWriterOnExistingLoggingConfiguration(
            LoggingConfiguration loggingConfiguration,
            System.IO.TextWriter textWriter)
        {
            if (loggingConfiguration == null)
            {
                throw new ArgumentNullException(nameof(loggingConfiguration));
            }

            if (textWriter == null)
            {
                throw new ArgumentNullException(nameof(textWriter));
            }

            ConfigureNLogToTextWriterOnExistingLoggingConfigurationInternal(
                loggingConfiguration,
                textWriter,
                LogLevel.Info);
        }

        public static void ConfigureNLogToTextWriterOnExistingLoggingConfiguration(
            LoggingConfiguration loggingConfiguration,
            System.IO.TextWriter textWriter,
            LogLevel minLevel,
            string loggerNamePattern = "*")
        {
            if (loggingConfiguration == null)
            {
                throw new ArgumentNullException(nameof(loggingConfiguration));
            }

            if (textWriter == null)
            {
                throw new ArgumentNullException(nameof(textWriter));
            }

            if (minLevel == null)
            {
                throw new ArgumentNullException(nameof(minLevel));
            }

            if (string.IsNullOrWhiteSpace(loggerNamePattern))
            {
                throw new ArgumentNullException(nameof(loggerNamePattern));
            }

            ConfigureNLogToTextWriterOnExistingLoggingConfigurationInternal(
                loggingConfiguration,
                textWriter,
                minLevel);
        }

        public static void ConfigureNLogToTextWriterOnExistingLoggingConfiguration(
            LoggingConfiguration loggingConfiguration,
            System.IO.TextWriter textWriter,
            LogLevel minLevel,
            LogLevel maxLevel,
            string loggerNamePattern = "*")
        {
            if (loggingConfiguration == null)
            {
                throw new ArgumentNullException(nameof(loggingConfiguration));
            }

            if (textWriter == null)
            {
                throw new ArgumentNullException(nameof(textWriter));
            }

            if (minLevel == null)
            {
                throw new ArgumentNullException(nameof(minLevel));
            }

            if (maxLevel == null)
            {
                throw new ArgumentNullException(nameof(maxLevel));
            }

            if (string.IsNullOrWhiteSpace(loggerNamePattern))
            {
                throw new ArgumentNullException(nameof(loggerNamePattern));
            }

            ConfigureLoggingRulesInternal(
                loggingConfiguration,
                textWriter,
                target => new LoggingRule(loggerNamePattern, minLevel, maxLevel, target));
        }

        /// <summary>
        /// Initializes NLog to TextWriter at Information Log Level
        /// </summary>
        /// <param name="textWriter">The text writer to target</param>
        public static void ConfigureNLogToTextWriterOnNewLoggingConfiguration(System.IO.TextWriter textWriter)
        {
            if (textWriter == null)
            {
                throw new ArgumentNullException(nameof(textWriter));
            }

            ConfigureNLogToTextWriterOnNewLoggingConfigurationInternal(textWriter, LogLevel.Info);
        }

        public static void ConfigureNLogToTextWriterOnNewLoggingConfiguration(
            System.IO.TextWriter textWriter,
            LogLevel minLevel,
            string loggerNamePattern = "*")
        {
            if (textWriter == null)
            {
                throw new ArgumentNullException(nameof(textWriter));
            }

            if (minLevel == null)
            {
                throw new ArgumentNullException(nameof(minLevel));
            }

            if (string.IsNullOrWhiteSpace(loggerNamePattern))
            {
                throw new ArgumentNullException(nameof(loggerNamePattern));
            }

            var loggingConfiguration = new LoggingConfiguration();

            ConfigureNLogToTextWriterOnExistingLoggingConfigurationInternal(
                loggingConfiguration,
                textWriter,
                minLevel,
                loggerNamePattern);

            NLog.LogManager.Configuration = loggingConfiguration;
        }

        public static void ConfigureNLogToTextWriterOnNewLoggingConfiguration(
            System.IO.TextWriter textWriter,
            LogLevel minLevel,
            LogLevel maxLevel,
            string loggerNamePattern = "*")
        {
            if (textWriter == null)
            {
                throw new ArgumentNullException(nameof(textWriter));
            }

            if (minLevel == null)
            {
                throw new ArgumentNullException(nameof(minLevel));
            }

            if (maxLevel == null)
            {
                throw new ArgumentNullException(nameof(maxLevel));
            }

            if (string.IsNullOrWhiteSpace(loggerNamePattern))
            {
                throw new ArgumentNullException(nameof(loggerNamePattern));
            }

            var loggingConfiguration = new LoggingConfiguration();
            ConfigureNLogToTextWriterOnExistingLoggingConfigurationInternal(
                loggingConfiguration,
                textWriter,
                minLevel,
                maxLevel,
                loggerNamePattern);

            NLog.LogManager.Configuration = loggingConfiguration;
        }

        private static void ConfigureNLogToTextWriterOnExistingLoggingConfigurationInternal(
            LoggingConfiguration loggingConfiguration,
            System.IO.TextWriter textWriter,
            LogLevel minLevel,
            LogLevel maxLevel,
            string loggerNamePattern = "*")
        {
            ConfigureLoggingRulesInternal(
                loggingConfiguration,
                textWriter,
                target => new LoggingRule(loggerNamePattern, minLevel, maxLevel, target));
        }

        private static void ConfigureNLogToTextWriterOnNewLoggingConfigurationInternal(
            System.IO.TextWriter textWriter,
            LogLevel minLevel,
            string loggerNamePattern = "*")
        {
            var loggingConfiguration = new LoggingConfiguration();

            ConfigureNLogToTextWriterOnExistingLoggingConfigurationInternal(
                loggingConfiguration,
                textWriter,
                minLevel,
                loggerNamePattern);

            NLog.LogManager.Configuration = loggingConfiguration;
        }

        private static void ConfigureNLogToTextWriterOnExistingLoggingConfigurationInternal(
            LoggingConfiguration loggingConfiguration,
            System.IO.TextWriter textWriter,
            LogLevel minLevel,
            string loggerNamePattern = "*")
        {
            ConfigureLoggingRulesInternal(
                loggingConfiguration,
                textWriter,
                target => new LoggingRule(loggerNamePattern, minLevel, target));
        }

        private static void ConfigureLoggingRulesInternal(
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