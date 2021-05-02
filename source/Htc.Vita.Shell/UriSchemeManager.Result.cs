namespace Htc.Vita.Shell
{
    public partial class UriSchemeManager
    {
        public class GetUriSchemeResult
        {
            public GetUriSchemeStatus Status { get; set; } = GetUriSchemeStatus.Unknown;
            public UriSchemeInfo UriScheme { get; set; }
        }
    }
}
