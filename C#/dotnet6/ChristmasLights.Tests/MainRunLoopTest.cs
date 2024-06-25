using Xunit;

namespace DotnetStarter.Logic.Tests
{
    public class MainRunLoopTest
    {
        [Fact]
        public void Hello_ReturnsWorld() => Assert.Equal("World!", MainRunLoop.Hello());
    }
}