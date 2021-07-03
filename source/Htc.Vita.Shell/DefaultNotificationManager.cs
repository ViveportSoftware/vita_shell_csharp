using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Htc.Vita.Core.Log;
using Htc.Vita.Core.Runtime;

namespace Htc.Vita.Shell
{
    /// <summary>
    /// Class DefaultNotificationManager.
    /// Implements the <see cref="NotificationManager" />
    /// </summary>
    /// <seealso cref="NotificationManager" />
    public partial class DefaultNotificationManager : NotificationManager
    {
        private const int DefaultNotifyIconTimeoutInMilli = 1000 * 5;

        private readonly Dictionary<NotifyIcon, KeyValuePair<long, NotificationInfo>> _notifyIconWithTimestampInMilli = new Dictionary<NotifyIcon, KeyValuePair<long, NotificationInfo>>();

        private static Assembly GetModuleAssembly()
        {
            return Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
        }

        private static Icon GetModuleAssemblyIcon()
        {
            Icon result = null;
            try
            {
                result = Icon.ExtractAssociatedIcon(GetModuleAssembly().Location);
            }
            catch (Exception e)
            {
                Logger.GetInstance(typeof(DefaultNotificationManager)).Error(e.ToString());
            }
            return result;
        }

        private void OnBalloonTipClicked(
                object sender,
                EventArgs e)
        {
            var notifyIcon = sender as NotifyIcon;
            if (notifyIcon == null)
            {
                return;
            }

            NotificationInfo notificationInfo = null;
            notifyIcon.Visible = false;
            lock (_notifyIconWithTimestampInMilli)
            {
                if (_notifyIconWithTimestampInMilli.ContainsKey(notifyIcon))
                {
                    var keyValuePair = _notifyIconWithTimestampInMilli[notifyIcon];
                    notificationInfo = keyValuePair.Value;
                    _notifyIconWithTimestampInMilli.Remove(notifyIcon);
                }
            }
            Logger.GetInstance(typeof(DefaultNotificationManager)).Debug($"notifyIcon[{notifyIcon.GetHashCode()}] is freed with notificationInfo[{notificationInfo?.Id}]");
            notifyIcon.Dispose();

            if (notificationInfo != null)
            {
                NotifyNotificationActivated(
                        notificationInfo,
                        notificationInfo.LaunchAction ?? DummyActionUri
                );
            }
        }

        private void OnBalloonTipClosed(
                object sender,
                EventArgs e)
        {
            var notifyIcon = sender as NotifyIcon;
            if (notifyIcon == null)
            {
                return;
            }

            NotificationInfo notificationInfo = null;
            notifyIcon.Visible = false;
            lock (_notifyIconWithTimestampInMilli)
            {
                if (_notifyIconWithTimestampInMilli.ContainsKey(notifyIcon))
                {
                    var keyValuePair = _notifyIconWithTimestampInMilli[notifyIcon];
                    notificationInfo = keyValuePair.Value;
                    _notifyIconWithTimestampInMilli.Remove(notifyIcon);
                }
            }
            Logger.GetInstance(typeof(DefaultNotificationManager)).Debug($"notifyIcon[{notifyIcon.GetHashCode()}] is freed with notificationInfo[{notificationInfo?.Id}]");
            notifyIcon.Dispose();

            if (notificationInfo != null)
            {
                NotifyNotificationDismissed(notificationInfo);
            }
        }

        /// <inheritdoc />
        protected override SendNotificationToSystemResult OnSendNotificationToSystem(NotificationInfo notificationInfo)
        {
            if (!Platform.IsWindows)
            {
                return new SendNotificationToSystemResult
                {
                        Status = SendNotificationToSystemStatus.UnsupportedSystem
                };
            }

            var version = Environment.OSVersion.Version;
            if (version.Major == 6
                    && version.Minor == 2
                    && version.Build == 9200)
            {
                Logger.GetInstance(typeof(DefaultNotificationManager)).Warn($"Version {version} detected. You may add app.manifest into your executable to correct Version API for Windows 8.1 or later");
            }

            SendNotificationToSystemResult result = null;
            if (version.Major == 10
                    && version.Minor == 0)
            {
                result = SendToastNotification(notificationInfo);
            }

            if (result == null || result.Status != SendNotificationToSystemStatus.Ok)
            {
                result = SendBalloonTipNotification(notificationInfo);
            }

            return result;
        }

        private SendNotificationToSystemResult SendBalloonTipNotification(NotificationInfo notificationInfo)
        {
            if (ShellContext.UIThread == null)
            {
                Logger.GetInstance(typeof(DefaultNotificationManager)).Error("Please set UI thread in ShellContext first to send Balloon Tip notification");
                return new SendNotificationToSystemResult
                {
                        Status = SendNotificationToSystemStatus.InvalidCallingThread
                };
            }

            if (ShellContext.UIThread != Thread.CurrentThread)
            {
                Logger.GetInstance(typeof(DefaultNotificationManager)).Error("Balloon Tip notification should be called in UI thread");
                return new SendNotificationToSystemResult
                {
                        Status = SendNotificationToSystemStatus.InvalidCallingThread
                };
            }

            var notifyIcon = new NotifyIcon
            {
                    BalloonTipIcon = ToolTipIcon.Info,
                    BalloonTipText = notificationInfo.TextSummary,
                    BalloonTipTitle = notificationInfo.Title,
                    Icon = GetModuleAssemblyIcon() ?? SystemIcons.Information,
                    Visible = true
            };

            notifyIcon.BalloonTipClicked -= OnBalloonTipClicked;
            notifyIcon.BalloonTipClicked += OnBalloonTipClicked;
            notifyIcon.BalloonTipClosed -= OnBalloonTipClosed;
            notifyIcon.BalloonTipClosed += OnBalloonTipClosed;

            notifyIcon.ShowBalloonTip(DefaultNotifyIconTimeoutInMilli);

            lock (_notifyIconWithTimestampInMilli)
            {
                _notifyIconWithTimestampInMilli[notifyIcon] = new KeyValuePair<long, NotificationInfo>(
                        Core.Util.Convert.ToTimestampInMilli(DateTime.UtcNow),
                        notificationInfo
                );
            }
            Logger.GetInstance(typeof(DefaultNotificationManager)).Debug($"notifyIcon[{notifyIcon.GetHashCode()}] is kept with notificationInfo[{notificationInfo.Id}]");

            return new SendNotificationToSystemResult
            {
                    Status = SendNotificationToSystemStatus.Ok
            };
        }

        private SendNotificationToSystemResult SendToastNotification(NotificationInfo notificationInfo)
        {
            return new SendNotificationToSystemResult
            {
                    Status = SendNotificationToSystemStatus.UnsupportedSystem
            };
        }
    }
}
