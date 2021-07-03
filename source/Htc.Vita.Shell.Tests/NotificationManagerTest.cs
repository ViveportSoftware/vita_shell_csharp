using System.Threading;
using Htc.Vita.Core.Runtime;
using Xunit;

namespace Htc.Vita.Shell.Tests
{
    public static class NotificationManagerTest
    {
        [Fact]
        public static void Default_0_GetInstance()
        {
            var notificationManager = NotificationManager.GetInstance();
            Assert.NotNull(notificationManager);
        }

        [Fact]
        public static void Default_1_SendNotificationToSystem()
        {
            if (!Platform.IsWindows)
            {
                return;
            }

            // Should be called on UI thread
            ShellContext.UIThread = Thread.CurrentThread;

            var notificationManager = NotificationManager.GetInstance();
            var notificationInfo = new NotificationManager.NotificationInfo
            {
                    TextBody = "Text body",
                    TextSummary = "Text summary",
                    Title = "Title"
            };
            var sendNotificationToSystemResult = notificationManager.SendNotificationToSystem(notificationInfo);
            var sendNotificationToSystemStatus = sendNotificationToSystemResult.Status;
            Assert.Equal(NotificationManager.SendNotificationToSystemStatus.Ok, sendNotificationToSystemStatus);
        }
    }
}
