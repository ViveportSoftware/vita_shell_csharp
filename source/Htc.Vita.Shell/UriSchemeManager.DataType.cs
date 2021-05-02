namespace Htc.Vita.Shell
{
    public partial class UriSchemeManager
    {
        /// <summary>
        /// Class UriSchemeInfo.
        /// </summary>
        public class UriSchemeInfo
        {
            /// <summary>
            /// Gets or sets the command path.
            /// </summary>
            /// <value>The command path.</value>
            public string CommandPath { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the command parameter.
            /// </summary>
            /// <value>The command parameter.</value>
            public string CommandParameter { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the default icon.
            /// </summary>
            /// <value>The default icon.</value>
            public string DefaultIcon { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get; set; } = string.Empty;
        }

        /// <summary>
        /// Enum GetUriSchemeStatus
        /// </summary>
        public enum GetUriSchemeStatus
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
            /// Not available
            /// </summary>
            NotAvailable,
            /// <summary>
            /// Unsupported platform
            /// </summary>
            UnsupportedPlatform
        }
    }
}
