using System;
using Htc.Vita.Core.Log;
using Htc.Vita.Core.Util;

namespace Htc.Vita.Shell
{
    /// <summary>
    /// Class IconManager.
    /// </summary>
    public abstract class IconManager
    {
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
        /// Called when flushing shell cache.
        /// </summary>
        /// <returns><c>true</c> if flushing the shell cache successfully, <c>false</c> otherwise.</returns>
        protected abstract bool OnFlushShellCache();
    }
}
