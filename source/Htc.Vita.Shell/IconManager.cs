using System;
using System.IO;
using Htc.Vita.Core.Log;
using Htc.Vita.Core.Util;

namespace Htc.Vita.Shell
{
    /// <summary>
    /// Class IconManager.
    /// </summary>
    public abstract class IconManager
    {
        /// <summary>
        /// Initializes static members of the <see cref="IconManager"/> class.
        /// </summary>
        static IconManager()
        {
            TypeRegistry.RegisterDefault<IconManager, DefaultIconManager>();
        }

        /// <summary>
        /// Registers the instance type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Register<T>()
                where T : IconManager, new()
        {
            TypeRegistry.Register<IconManager, T>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>IconManager.</returns>
        public static IconManager GetInstance()
        {
            return TypeRegistry.GetInstance<IconManager>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IconManager.</returns>
        public static IconManager GetInstance<T>()
                where T : IconManager, new()
        {
            return TypeRegistry.GetInstance<IconManager, T>();
        }

        /// <summary>
        /// Extracts the icon from file.
        /// </summary>
        /// <param name="fromFile">Source file.</param>
        /// <param name="toIcon">Target icon.</param>
        /// <returns><c>true</c> if extracting icon from file successfully, <c>false</c> otherwise.</returns>
        public bool ExtractIconFromFile(
                FileInfo fromFile,
                FileInfo toIcon)
        {
            if (fromFile == null || toIcon == null)
            {
                return false;
            }

            var realFromFile = new FileInfo(fromFile.FullName);
            if (!realFromFile.Exists)
            {
                return false;
            }

            var result = false;
            try
            {
                result = OnExtractIconFromFile(
                        realFromFile,
                        new FileInfo(toIcon.FullName)
                );
            }
            catch (Exception e)
            {
                Logger.GetInstance(typeof(IconManager)).Error(e.ToString());
            }
            return result;
        }

        /// <summary>
        /// Flushes the shell cache.
        /// </summary>
        /// <returns><c>true</c> if flushing the shell cache successfully, <c>false</c> otherwise.</returns>
        public bool FlushShellCache()
        {
            var result = false;
            try
            {
                result = OnFlushShellCache();
            }
            catch (Exception e)
            {
                Logger.GetInstance(typeof(IconManager)).Error(e.ToString());
            }
            return result;
        }

        /// <summary>
        /// Called when extracting icon from file.
        /// </summary>
        /// <param name="fromFile">Source file.</param>
        /// <param name="toIcon">Target icon.</param>
        /// <returns><c>true</c> if extracting icon from file successfully, <c>false</c> otherwise.</returns>
        protected abstract bool OnExtractIconFromFile(
                FileInfo fromFile,
                FileInfo toIcon
        );
        /// <summary>
        /// Called when flushing shell cache.
        /// </summary>
        /// <returns><c>true</c> if flushing the shell cache successfully, <c>false</c> otherwise.</returns>
        protected abstract bool OnFlushShellCache();
    }
}
