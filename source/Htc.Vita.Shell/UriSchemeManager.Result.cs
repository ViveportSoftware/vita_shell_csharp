namespace Htc.Vita.Shell
{
    public partial class UriSchemeManager
    {
        /// <summary>
        /// Class GetUriSchemeResult.
        /// </summary>
        public class GetUriSchemeResult
        {
            /// <summary>
            /// Gets or sets the status.
            /// </summary>
            /// <value>The status.</value>
            public GetUriSchemeStatus Status { get; set; } = GetUriSchemeStatus.Unknown;
            /// <summary>
            /// Gets or sets the URI scheme.
            /// </summary>
            /// <value>The URI scheme.</value>
            public UriSchemeInfo UriScheme { get; set; }
        }
    }
}
