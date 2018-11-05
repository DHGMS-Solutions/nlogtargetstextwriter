using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using NLog.Config;
using Xunit;

namespace NLog.Targets.TextWriter.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class NLogTextWriterHelpersTests
    {
        public sealed class ConfigureNLogToTextWriterOnExistingLoggingConfigurationMethod
        {
            [Fact]
            public void ThrowsArgumentNullExceptionForLoggingConfiguration()
            {
                using (var textWriter = new StringWriter())
                {
                    var exception = Assert.Throws<ArgumentNullException>(() => NLogTextWriterHelpers.ConfigureNLogToTextWriterOnExistingLoggingConfiguration(null, textWriter));
                    Assert.Equal("loggingConfiguration", exception.ParamName);
                }
            }

            [Fact]
            public void ThrowsArgumentNullExceptionForTextWriter()
            {
                var loggingConfiguration = new LoggingConfiguration();
                var exception = Assert.Throws<ArgumentNullException>(() => NLogTextWriterHelpers.ConfigureNLogToTextWriterOnExistingLoggingConfiguration(loggingConfiguration, null));
                Assert.Equal("textWriter", exception.ParamName);
            }

            [Fact]
            public void ShouldSucceedForTextWriter()
            {
                using (var textWriter = new StringWriter())
                {
                    var loggingConfiguration = new LoggingConfiguration();
                    NLogTextWriterHelpers.ConfigureNLogToTextWriterOnExistingLoggingConfiguration(loggingConfiguration, textWriter);
                }
            }

            [Fact]
            public void ShouldSucceedForMinLevel()
            {
                using (var textWriter = new StringWriter())
                {
                    var loggingConfiguration = new LoggingConfiguration();
                    NLogTextWriterHelpers.ConfigureNLogToTextWriterOnExistingLoggingConfiguration(loggingConfiguration, textWriter, LogLevel.Debug);
                }
            }

            [Fact]
            public void ShouldSucceedForMaxLevel()
            {
                using (var textWriter = new StringWriter())
                {
                    var loggingConfiguration = new LoggingConfiguration();
                    NLogTextWriterHelpers.ConfigureNLogToTextWriterOnExistingLoggingConfiguration(loggingConfiguration, textWriter, LogLevel.Debug, LogLevel.Error);
                }
            }
        }

        public sealed class ConfigureNLogToTextWriterOnNewLoggingConfigurationMethod
        {
            [Fact]
            public void ThrowsArgumentNullExceptionForTextWriter()
            {
                var exception = Assert.Throws<ArgumentNullException>(() => NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration(null));
                Assert.Equal("textWriter", exception.ParamName);
            }

            [Fact]
            public void ThrowsArgumentNullExceptionForMinLevel()
            {
                using (var textWriter = new StringWriter())
                {
                    var exception = Assert.Throws<ArgumentNullException>(() => NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration(textWriter, null));
                    Assert.Equal("minLevel", exception.ParamName);
                }
            }

            [Fact]
            public void ThrowsArgumentNullExceptionForMaxLevel()
            {
                using (var textWriter = new StringWriter())
                {
                    var exception = Assert.Throws<ArgumentNullException>(() => NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration(textWriter, LogLevel.Debug, (LogLevel)null));
                    Assert.Equal("maxLevel", exception.ParamName);
                }
            }

            [Fact]
            public void ThrowsArgumentNullExceptionForLoggerNamePattern()
            {
                using (var textWriter = new StringWriter())
                {
                    var exception = Assert.Throws<ArgumentNullException>(() => NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration(textWriter, LogLevel.Debug, LogLevel.Error, null));
                    Assert.Equal("loggerNamePattern", exception.ParamName);
                }
            }

            [Fact]
            public void ShouldSucceedForTextWriter()
            {
                using (var textWriter = new StringWriter())
                {
                    NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration(textWriter);
                }
            }

            [Fact]
            public void ShouldSucceedForMinLevel()
            {
                using (var textWriter = new StringWriter())
                {
                    NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration(textWriter, LogLevel.Debug);
                }
            }

            [Fact]
            public void ShouldSucceedForMaxLevel()
            {
                using (var textWriter = new StringWriter())
                {
                    NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration(textWriter, LogLevel.Debug, LogLevel.Error);
                }
            }
        }
    }
}