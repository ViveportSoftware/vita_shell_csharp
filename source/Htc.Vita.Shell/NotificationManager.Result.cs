namespace Htc.Vita.Shell
{
    public partial class NotificationManager
    {
        /// <summary>
        /// Class SendNotificationToSystemResult.
        /// </summary>
        public class SendNotificationToSystemResult
        {
            /// <summary>
            /// Gets or sets the status.
            /// </summary>
            /// <value>The status.</value>
            public SendNotificationToSystemStatus Status { get; set; } = SendNotificationToSystemStatus.Unknown;
        }

        /// <summary>
        /// Enum SendNotificationToSystemStatus
        /// </summary>
        public enum SendNotificationToSystemStatus
        {
            /// <summary>
            /// Unknown
            /// </summary>
            Unknown,
            /// <summary>
            /// Ok
            /// </summary>
            Ok,
            /// <summary>
            /// Invalid data
            /// </summary>
            InvalidData,
            /// <summary>
            /// Invalid calling thread
            /// </summary>
            InvalidCallingThread,
            /// <summary>
            /// Unsupported system
            /// </summary>
            UnsupportedSystem
        }
    }
}
