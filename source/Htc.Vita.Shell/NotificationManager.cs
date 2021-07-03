using System;
using System.Threading.Tasks;
using Htc.Vita.Core.Log;
using Htc.Vita.Core.Util;

namespace Htc.Vita.Shell
{
    /// <summary>
    /// Class NotificationManager.
    /// </summary>
    public abstract partial class NotificationManager
    {
        /// <summary>
        /// Gets the dummy action URI.
        /// </summary>
        /// <value>The dummy action URI.</value>
        public static Uri DummyActionUri => new Uri("dummyaction://dummyhost");

        /// <summary>
        /// Occurs when the notification is activated.
        /// </summary>
        public event Action<NotificationInfo, Uri> OnNotificationActivated;
        /// <summary>
        /// Occurs when the notification is dismissed.
        /// </summary>
        public event Action<NotificationInfo> OnNotificationDismissed;

        /// <summary>
        /// Initializes static members of the <see cref="NotificationManager"/> class.
        /// </summary>
        static NotificationManager()
        {
            TypeRegistry.RegisterDefault<NotificationManager, DefaultNotificationManager>();
        }

        /// <summary>
        /// Registers the instance type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Register<T>()
                where T : NotificationManager, new()
        {
            TypeRegistry.Register<NotificationManager, T>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>NotificationManager.</returns>
        public static NotificationManager GetInstance()
        {
            return TypeRegistry.GetInstance<NotificationManager>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>NotificationManager.</returns>
        public static NotificationManager GetInstance<T>()
                where T : NotificationManager, new()
        {
            return TypeRegistry.GetInstance<NotificationManager, T>();
        }

        /// <summary>
        /// Notifies the notification activated.
        /// </summary>
        /// <param name="notificationInfo">The notification information.</param>
        /// <param name="actionUri">The action URI.</param>
        protected void NotifyNotificationActivated(
                NotificationInfo notificationInfo,
                Uri actionUri)
        {
            if (notificationInfo == null || actionUri == null)
            {
                return;
            }

            Task.Run(() =>
            {
                    try
                    {
                        OnNotificationActivated?.Invoke(
                                notificationInfo,
                                actionUri
                        );
                    }
                    catch (Exception e)
                    {
                        Logger.GetInstance(typeof(NotificationManager)).Error(e.ToString());
                    }
            });
        }

        /// <summary>
        /// Notifies the notification dismissed.
        /// </summary>
        /// <param name="notificationInfo">The notification information.</param>
        protected void NotifyNotificationDismissed(NotificationInfo notificationInfo)
        {
            if (notificationInfo == null)
            {
                return;
            }

            Task.Run(() =>
            {
                    try
                    {
                        OnNotificationDismissed?.Invoke(
                                notificationInfo
                        );
                    }
                    catch (Exception e)
                    {
                        Logger.GetInstance(typeof(NotificationManager)).Error(e.ToString());
                    }
            });
        }

        /// <summary>
        /// Sends the notification to system.
        /// </summary>
        /// <param name="notificationInfo">The notification information.</param>
        /// <returns>SendNotificationToSystemResult.</returns>
        public SendNotificationToSystemResult SendNotificationToSystem(NotificationInfo notificationInfo)
        {
            if (notificationInfo == null)
            {
                return new SendNotificationToSystemResult
                {
                        Status = SendNotificationToSystemStatus.InvalidData
                };
            }

            SendNotificationToSystemResult result = null;
            try
            {
                result = OnSendNotificationToSystem(notificationInfo);
            }
            catch (Exception e)
            {
                Logger.GetInstance(typeof(NotificationManager)).Error(e.ToString());
            }
            return result ?? new SendNotificationToSystemResult();
        }

        /// <summary>
        /// Called when sending notification to system.
        /// </summary>
        /// <param name="notificationInfo">The notification information.</param>
        /// <returns>SendNotificationToSystemResult.</returns>
        protected abstract SendNotificationToSystemResult OnSendNotificationToSystem(NotificationInfo notificationInfo);
    }
}
