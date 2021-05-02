using System;
using Htc.Vita.Core.Log;
using Htc.Vita.Core.Runtime;
using Htc.Vita.Shell.Interop;

namespace Htc.Vita.Shell
{
    /// <summary>
    /// Class DefaultIconManager.
    /// Implements the <see cref="IconManager" />
    /// </summary>
    /// <seealso cref="IconManager" />
    public class DefaultIconManager : IconManager
    {
        /// <inheritdoc />
        protected override bool OnFlushShellCache()
        {
            if (!Platform.IsWindows)
            {
                return false;
            }

            var result = false;
            try
            {
                Windows.SHChangeNotify(
                        Windows.ShellChangeNotifyEventIds.AssociationChanged,
                        Windows.ShellChangeNotifyFlags.IdList,
                        IntPtr.Zero,
                        IntPtr.Zero
                );
                result = true;
            }
            catch (Exception e)
            {
                Logger.GetInstance(typeof(DefaultIconManager)).Error($"Can not notify association change to shell: {e.Message}");
            }
            return result;
        }
    }
}
