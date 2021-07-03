using System.Threading;

namespace Htc.Vita.Shell
{
    /// <summary>
    /// Class ShellContext.
    /// </summary>
    public class ShellContext
    {
        /// <summary>
        /// Gets or sets the UI thread.
        /// </summary>
        /// <value>The UI thread.</value>
        public static Thread UIThread { get; set; }
    }
}
