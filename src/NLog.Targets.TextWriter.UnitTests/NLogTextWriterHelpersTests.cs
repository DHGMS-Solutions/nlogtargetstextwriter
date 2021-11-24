using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using NLog.Config;
using Xunit;

namespace NLog.Targets.TextWriter.UnitTests
{
    /// <summary>
    /// Unit Tests for the <see cref="T:NLog.Targets.NLogTextWriterHelpers"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class NLogTextWriterHelpersTests
    {
        /// <summary>
        /// Unit Tests for the <see cref="M:NLog.Targets.NLogTextWriterHelpers.ConfigureNLogToTextWriterOnExistingLoggingConfiguration"/> method.
        /// </summary>
        public sealed class ConfigureNLogToTextWriterOnExistingLoggingConfigurationMethod
        {
            /// <summary>
            /// Test to ensure an argument null exception is thrown for no logging configuration being passed.
            /// </summary>
            [Fact]
            public void ThrowsArgumentNullExceptionForLoggingConfiguration()
            {
                using (var textWriter = new StringWriter())
                {
                    var exception = Assert.Throws<ArgumentNullException>(() => NLogTextWriterHelpers.ConfigureNLogToTextWriterOnExistingLoggingConfiguration(null, textWriter));
                    Assert.Equal("loggingConfiguration", exception.ParamName);
                }
            }

            /// <summary>
            /// Test to ensure an argument null exception is thrown for no text writer being passed.
            /// </summary>
            [Fact]
            public void ThrowsArgumentNullExceptionForTextWriter()
            {
                var loggingConfiguration = new LoggingConfiguration();
                var exception = Assert.Throws<ArgumentNullException>(() => NLogTextWriterHelpers.ConfigureNLogToTextWriterOnExistingLoggingConfiguration(loggingConfiguration, null));
                Assert.Equal("textWriter", exception.ParamName);
            }

            /// <summary>
            /// Test to ensure configuration succeeds when a text writer is passed.
            /// </summary>
            [Fact]
            public void ShouldSucceedForTextWriter()
            {
                using (var textWriter = new StringWriter())
                {
                    var loggingConfiguration = new LoggingConfiguration();
                    NLogTextWriterHelpers.ConfigureNLogToTextWriterOnExistingLoggingConfiguration(loggingConfiguration, textWriter);
                }
            }

            /// <summary>
            /// Test to ensure configuration succeeds when a minimum log level is passed.
            /// </summary>
            [Fact]
            public void ShouldSucceedForMinLevel()
            {
                using (var textWriter = new StringWriter())
                {
                    var loggingConfiguration = new LoggingConfiguration();
                    NLogTextWriterHelpers.ConfigureNLogToTextWriterOnExistingLoggingConfiguration(loggingConfiguration, textWriter, LogLevel.Debug);
                }
            }

            /// <summary>
            /// Test to ensure configuration succeeds when a maximum log level is passed.
            /// </summary>
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

        /// <summary>
        /// Unit Tests for the <see cref="M:NLog.Targets.NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration"/> methods.
        /// </summary>
        public sealed class ConfigureNLogToTextWriterOnNewLoggingConfigurationMethod
        {
            /// <summary>
            /// Test to ensure an argument null exception is thrown for no text writer being passed.
            /// </summary>
            [Fact]
            public void ThrowsArgumentNullExceptionForTextWriter()
            {
                var exception = Assert.Throws<ArgumentNullException>(() => NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration(null));
                Assert.Equal("textWriter", exception.ParamName);
            }

            /// <summary>
            /// Test to ensure an argument null exception is thrown for no logging configuration being passed.
            /// </summary>
            [Fact]
            public void ThrowsArgumentNullExceptionForMinLevel()
            {
                using (var textWriter = new StringWriter())
                {
                    var exception = Assert.Throws<ArgumentNullException>(() => NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration(textWriter, null));
                    Assert.Equal("minLevel", exception.ParamName);
                }
            }

            /// <summary>
            /// Test to ensure an argument null exception is thrown for no minimum log level being passed.
            /// </summary>
            [Fact]
            public void ThrowsArgumentNullExceptionForMaxLevel()
            {
                using (var textWriter = new StringWriter())
                {
                    var exception = Assert.Throws<ArgumentNullException>(() => NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration(textWriter, LogLevel.Debug, (LogLevel)null));
                    Assert.Equal("maxLevel", exception.ParamName);
                }
            }

            /// <summary>
            /// Test to ensure an argument null exception is thrown for no logger name pattern being passed.
            /// </summary>
            [Fact]
            public void ThrowsArgumentNullExceptionForLoggerNamePattern()
            {
                using (var textWriter = new StringWriter())
                {
                    var exception = Assert.Throws<ArgumentNullException>(() => NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration(textWriter, LogLevel.Debug, LogLevel.Error, null));
                    Assert.Equal("loggerNamePattern", exception.ParamName);
                }
            }

            /// <summary>
            /// Test to ensure configuration succeeds when a text writer is passed.
            /// </summary>
            [Fact]
            public void ShouldSucceedForTextWriter()
            {
                using (var textWriter = new StringWriter())
                {
                    NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration(textWriter);
                }
            }

            /// <summary>
            /// Test to ensure configuration succeeds when a minimum log level is passed.
            /// </summary>
            [Fact]
            public void ShouldSucceedForMinLevel()
            {
                using (var textWriter = new StringWriter())
                {
                    NLogTextWriterHelpers.ConfigureNLogToTextWriterOnNewLoggingConfiguration(textWriter, LogLevel.Debug);
                }
            }

            /// <summary>
            /// Test to ensure configuration succeeds when a maximum log level is passed.
            /// </summary>
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