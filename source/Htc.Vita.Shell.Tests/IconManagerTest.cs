using Xunit;

namespace Htc.Vita.Shell.Tests
{
    public static class IconManagerTest
    {
        [Fact]
        public static void Default_0_GetInstance()
        {
            var iconManager = IconManager.GetInstance();
            Assert.NotNull(iconManager);
        }

        [Fact]
        public static void Default_1_FlushShellCache()
        {
            if (!Core.Runtime.Platform.IsWindows)
            {
                return;
            }

            var iconManager = IconManager.GetInstance();
            Assert.NotNull(iconManager);
            Assert.True(iconManager.FlushShellCache());
        }
    }
}
