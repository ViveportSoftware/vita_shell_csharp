using System;
using System.Threading;
using System.Windows.Forms;
using Htc.Vita.Core.Log;

namespace Htc.Vita.Shell.TestProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShellContext.UIThread = Thread.CurrentThread;

            var notificationManager = NotificationManager.GetInstance();
            notificationManager.OnNotificationActivated += OnNotificationActivated;
            notificationManager.OnNotificationDismissed += OnNotificationDismissed;
            
            var notificationInfo1 = new NotificationManager.NotificationInfo
            {
                    LaunchAction = new Uri("action://my/test?id=123"),
                    TextSummary = "Text summary 1",
                    TextBody = "Text body 1",
                    Title = "Title 1"
            };
            var notificationInfo2 = new NotificationManager.NotificationInfo
            {
                    TextBody = "Text body 2",
                    TextSummary = "Text summary 2",
                    Title = "Title 2"
            };
            var sendNotificationToSystemResult = notificationManager.SendNotificationToSystem(notificationInfo1);
            var sendNotificationToSystemStatus = sendNotificationToSystemResult.Status;
            if (sendNotificationToSystemStatus != NotificationManager.SendNotificationToSystemStatus.Ok)
            {
                Logger.GetInstance(typeof(Program)).Error($"Can not send notification. status: {sendNotificationToSystemStatus}");
            }
            sendNotificationToSystemResult = notificationManager.SendNotificationToSystem(notificationInfo2);
            sendNotificationToSystemStatus = sendNotificationToSystemResult.Status;
            if (sendNotificationToSystemStatus != NotificationManager.SendNotificationToSystemStatus.Ok)
            {
                Logger.GetInstance(typeof(Program)).Error($"Can not send notification. status: {sendNotificationToSystemStatus}");
            }
            Application.Run();
        }

        private static void OnNotificationActivated(
                NotificationManager.NotificationInfo notificationInfo,
                Uri actionUri)
        {
            Logger.GetInstance(typeof(Program)).Info($"notification[{notificationInfo.Id}] is activated with action: \"{actionUri}\"");
        }

        private static void OnNotificationDismissed(NotificationManager.NotificationInfo notificationInfo)
        {
            Logger.GetInstance(typeof(Program)).Info($"notification[{notificationInfo.Id}] is dismissed");
        }
    }
}
