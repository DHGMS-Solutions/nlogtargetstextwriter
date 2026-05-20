using Xunit;

namespace NLog.Targets.TextWriter.IntegrationTests
{
    public static class FakeTest
    {
        [Fact]
        public static void DoNothing()
        {
            Assert.True(true);
        }
    }
}
