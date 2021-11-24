namespace NLog.Targets.TextWriter.UnitTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    using NLog;
    using NLog.Common;

    using Xunit;

    /// <summary>
    /// Unit Tests for the <see cref="T:NLog.Targets.TextWriterTarget"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class TextWriterTargetTests
    {
        /// <summary>
        /// Unit Tests for the <see cref="M:NLog.Targets.TextWriterTarget.TextWriterTarget"/> method.
        /// </summary>
        public sealed class ConstructorMethod
        {
            /// <summary>
            /// Test to ensure an argument null exception is thrown if no Text Writer is passed.
            /// </summary>
            [Fact]
            public void ThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new TextWriterTarget(null));
            }

            /// <summary>
            /// Test to ensure an instance is created.
            /// </summary>
            [Fact]
            public void ReturnsInstance()
            {
                using (var textWriter = new StringWriter())
                using (var instance = new TextWriterTarget(textWriter))
                {
                    Assert.NotNull(instance);
                }
            }
        }

        /// <summary>
        /// Unit Tests for the <see cref="M:NLog.Targets.TextWriterTarget.WriteAsyncLogEvent"/> method.
        /// </summary>
        public sealed class WriteAsyncLogEventMethod
        {
            /// <summary>
            /// Test to ensure a message can be written.
            /// </summary>
            [Fact]
            public void WritesMessage()
            {
                using (var textWriter = new StringWriter())
                using (var instance = new TextWriterTarget(textWriter))
                {
                    var logEventInfo = new LogEventInfo(LogLevel.Debug, "UNITTEST", "MESSAGE");
                    var logEvent = new AsyncLogEventInfo(logEventInfo, exception => { });
                    instance.WriteAsyncLogEvent(logEvent);
                    instance.Flush(exception => { });
                }
            }
        }
    }
}