using Htc.Vita.Core.Runtime;
using Xunit;
using Xunit.Abstractions;

namespace Htc.Vita.Shell.Tests
{
    public class UriSchemeManagerTest
    {
        private readonly ITestOutputHelper _output;

        public UriSchemeManagerTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Default_0_GetInstance()
        {
            var uriSchemeManager = UriSchemeManager.GetInstance();
            Assert.NotNull(uriSchemeManager);
        }

        [Fact]
        public void Default_1_GetSystemUriScheme()
        {
            if (!Platform.IsWindows)
            {
                return;
            }

            var uriSchemeManager = UriSchemeManager.GetInstance();

            var getUriSchemeResult = uriSchemeManager.GetSystemUriScheme("http");
            var getUriSchemeStatus = getUriSchemeResult.Status;
            Assert.Equal(UriSchemeManager.GetUriSchemeStatus.Ok, getUriSchemeStatus);

            var systemUriScheme = getUriSchemeResult.UriScheme;
            _output.WriteLine($"systemUriScheme.Name: \"{systemUriScheme.Name}\"");
            Assert.False(string.IsNullOrEmpty(systemUriScheme.Name));
            _output.WriteLine($"systemUriScheme.DefaultIcon: \"{systemUriScheme.DefaultIcon}\"");
            Assert.False(string.IsNullOrEmpty(systemUriScheme.DefaultIcon));
            _output.WriteLine($"systemUriScheme.CommandPath: \"{systemUriScheme.CommandPath}\"");
            Assert.False(string.IsNullOrEmpty(systemUriScheme.CommandPath));
            _output.WriteLine($"systemUriScheme.CommandParameter: \"{systemUriScheme.CommandParameter}\"");
            Assert.False(string.IsNullOrEmpty(systemUriScheme.CommandParameter));

            getUriSchemeResult = uriSchemeManager.GetSystemUriScheme("http2");
            getUriSchemeStatus = getUriSchemeResult.Status;
            Assert.Equal(UriSchemeManager.GetUriSchemeStatus.NotAvailable, getUriSchemeStatus);
        }
    }
}
