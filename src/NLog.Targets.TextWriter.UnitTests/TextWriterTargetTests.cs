namespace NLog.Targets.TextWriter.UnitTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    using NLog;
    using NLog.Common;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public static class TextWriterTargetTests
    {
        public sealed class ConstructorMethod
        {
            [Fact]
            public void ThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new TextWriterTarget(null));
            }

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

        public sealed class WriteMethod
        {
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