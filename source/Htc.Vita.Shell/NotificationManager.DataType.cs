using System;
using System.Collections.Generic;
using System.Diagnostics;
using Htc.Vita.Core.Crypto;

namespace Htc.Vita.Shell
{
    public partial class NotificationManager
    {
        /// <summary>
        /// Class NotificationActionInfo.
        /// </summary>
        public class NotificationActionInfo
        {
            /// <summary>
            /// Gets the default display name.
            /// </summary>
            /// <value>The default display name.</value>
            public static string DefaultDisplayName => "[Undefined Display Name]";

            /// <summary>
            /// Gets or sets the action URI.
            /// </summary>
            /// <value>The action URI.</value>
            public Uri ActionUri { get; set; }
            /// <summary>
            /// Gets or sets the display name.
            /// </summary>
            /// <value>The display name.</value>
            public string DisplayName { get; set; } = DefaultDisplayName;
            /// <summary>
            /// Gets or sets a value indicating whether this action is default.
            /// </summary>
            /// <value><c>true</c> if this action is default; otherwise, <c>false</c>.</value>
            public bool IsDefault { get; set; }
        }

        /// <summary>
        /// Class NotificationInfo.
        /// </summary>
        public class NotificationInfo
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="NotificationInfo" /> class.
            /// </summary>
            public NotificationInfo()
            {
                var processId = Process.GetCurrentProcess().Id;
                var timestamp = Core.Util.Convert.ToTimestampInMilli(DateTime.UtcNow);
                Id = Sha1.GetInstance().GenerateInBase64($"{processId}_{timestamp}");
            }

            /// <summary>
            /// Gets the default group header.
            /// </summary>
            /// <value>The default group header.</value>
            public static string DefaultGroupHeader => "[Undefined Group Header]";
            /// <summary>
            /// Gets the default text body.
            /// </summary>
            /// <value>The default text body.</value>
            public static string DefaultTextBody => "[Undefined Text Body]";
            /// <summary>
            /// Gets the default text summary.
            /// </summary>
            /// <value>The default text summary.</value>
            public static string DefaultTextSummary => "[Undefined Text Summary]";
            /// <summary>
            /// Gets the default title.
            /// </summary>
            /// <value>The default title.</value>
            public static string DefaultTitle => "[Undefined Title]";

            /// <summary>
            /// Gets or sets the group header.
            /// </summary>
            /// <value>The group header.</value>
            public string GroupHeader { get; set; } = DefaultGroupHeader;
            /// <summary>
            /// Gets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            public string Id { get; }
            /// <summary>
            /// Gets or sets the launch action.
            /// </summary>
            /// <value>The launch action.</value>
            public Uri LaunchAction { get; set; }
            /// <summary>
            /// Gets or sets the logo override.
            /// </summary>
            /// <value>The logo override.</value>
            public Uri LogoOverride { get; set; }
            /// <summary>
            /// Gets or sets the text body.
            /// </summary>
            /// <value>The text body.</value>
            public string TextBody { get; set; } = DefaultTextBody;
            /// <summary>
            /// Gets or sets the text summary.
            /// </summary>
            /// <value>The text summary.</value>
            public string TextSummary { get; set; } = DefaultTextSummary;
            /// <summary>
            /// Gets or sets the title.
            /// </summary>
            /// <value>The title.</value>
            public string Title { get; set; } = DefaultTitle;
        }
    }
}
