using System;
using System.IO;
using Htc.Vita.Core.Runtime;
using Xunit;

namespace Htc.Vita.Shell.Tests
{
    public static class LinkManagerTest
    {
        [Fact]
        public static void Default_0_GetInstance()
        {
            var linkManager = LinkManager.GetInstance();
            Assert.NotNull(linkManager);
        }

        [Fact]
        public static void Default_1_Create_withFileLinkInfo()
        {
            if (!Platform.IsWindows)
            {
                return;
            }

            var target = Environment.GetEnvironmentVariable("Temp");
            Assert.NotNull(target);
            var intermediatePathName = $"FileLink-{Core.Util.Convert.ToTimestampInMilli(DateTime.UtcNow)}";
            target = Path.Combine(target, intermediatePathName, "shell32.dll");
            var fileLinkInfo = new LinkManager.FileLinkInfo
            {
                    SourcePath = new FileInfo("C:\\Windows\\System32\\shell32.dll"),
                    TargetPath = new FileInfo(target),
                    TargetIconPath = new FileInfo("C:\\Windows\\System32\\shell32.dll"),
                    TargetIconIndex = 5
            };
            var linkManager = LinkManager.GetInstance();
            Assert.True(linkManager.Create(fileLinkInfo));
        }

        [Fact]
        public static void Default_1_Create_withShellLinkInfo()
        {
            if (!Platform.IsWindows)
            {
                return;
            }

            var target = Environment.GetEnvironmentVariable("Temp");
            Assert.NotNull(target);
            var workingPath = target;
            var intermediatePathName = $"ShellLink-{Core.Util.Convert.ToTimestampInMilli(DateTime.UtcNow)}";
            target = Path.Combine(target, intermediatePathName, "notepad.exe");
            var shellLinkInfo = new LinkManager.ShellLinkInfo
            {
                    SourcePath = new FileInfo("C:\\Windows\\System32\\notepad.exe"),
                    TargetPath = new FileInfo(target),
                    TargetIconPath = new FileInfo("C:\\Windows\\System32\\shell32.dll"),
                    TargetIconIndex = 5,
                    Description = "MyDescription",
                    SourceAppId = "HTC.Vita.Shell.Tests",
                    SourceActivatorId = new Guid("3427c537-c3b5-4737-bae3-d7e3dc564d87"),
                    SourceArguments = "--test",
                    SourceWindowState = LinkManager.ShellLinkWindowState.Maximized,
                    SourceWorkingPath = new DirectoryInfo(workingPath)
            };
            var linkManager = LinkManager.GetInstance();
            Assert.True(linkManager.Create(shellLinkInfo));
        }
    }
}
