using System;
using System.Drawing;
using System.IO;
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
        protected override bool OnExtractIconFromFile(
                FileInfo fromFile,
                FileInfo toIcon)
        {
            if (!Platform.IsWindows)
            {
                return false;
            }

            var targetPathDir = toIcon.Directory;
            if (targetPathDir != null && !targetPathDir.Exists)
            {
                targetPathDir.Create();
            }

            try
            {
                using (var icon = Icon.ExtractAssociatedIcon(fromFile.FullName))
                {
                    if (icon == null)
                    {
                        return false;
                    }
                    using (var stream = new FileStream(toIcon.FullName, FileMode.CreateNew))
                    {
                        icon.Save(stream);
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                Logger.GetInstance(typeof(DefaultIconManager)).Error($"Can not extract icon to path: {e.Message}");
            }
            return false;
        }

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
