using System;
using System.IO;
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
            Assert.True(iconManager.FlushShellCache());
        }

        [Fact]
        public static void Default_2_ExtractIconFromFile()
        {
            if (!Core.Runtime.Platform.IsWindows)
            {
                return;
            }

            var sourceFileInfo = new FileInfo("C:\\Windows\\System32\\shell32.dll");
            Assert.True(sourceFileInfo.Exists);
            var target = Environment.GetEnvironmentVariable("Temp");
            Assert.NotNull(target);
            var intermediatePathName = $"Icon-{Core.Util.Convert.ToTimestampInMilli(DateTime.UtcNow)}";
            target = Path.Combine(target, intermediatePathName, "shell32.ico");
            var targetFileInfo = new FileInfo(target);
            var iconManager = IconManager.GetInstance();
            Assert.True(iconManager.ExtractIconFromFile(sourceFileInfo, targetFileInfo));
            Assert.True(targetFileInfo.Exists);
        }
    }
}
