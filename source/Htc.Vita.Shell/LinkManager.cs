using System;
using Htc.Vita.Core.Log;
using Htc.Vita.Core.Util;

namespace Htc.Vita.Shell
{
    /// <summary>
    /// Class LinkManager.
    /// </summary>
    public abstract partial class LinkManager
    {
        /// <summary>
        /// Initializes static members of the <see cref="LinkManager" /> class.
        /// </summary>
        static LinkManager()
        {
            TypeRegistry.RegisterDefault<LinkManager, DefaultLinkManager>();
        }

        /// <summary>
        /// Registers the instance type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Register<T>()
                where T : LinkManager, new()
        {
            TypeRegistry.Register<LinkManager, T>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>LinkManager.</returns>
        public static LinkManager GetInstance()
        {
            return TypeRegistry.GetInstance<LinkManager>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>LinkManager.</returns>
        public static LinkManager GetInstance<T>()
                where T : LinkManager, new()
        {
            return TypeRegistry.GetInstance<LinkManager, T>();
        }

        /// <summary>
        /// Creates the specified file link.
        /// </summary>
        /// <param name="fileLinkInfo">The file link information.</param>
        /// <returns><c>true</c> if creating the specified file link successfully, <c>false</c> otherwise.</returns>
        public bool Create(FileLinkInfo fileLinkInfo)
        {
            if (fileLinkInfo == null)
            {
                return false;
            }

            var result = false;
            try
            {
                result = OnCreate(fileLinkInfo);
            }
            catch (Exception e)
            {
                Logger.GetInstance(typeof(LinkManager)).Error(e.ToString());
            }
            return result;
        }

        /// <summary>
        /// Creates the specified shell link.
        /// </summary>
        /// <param name="shellLinkInfo">The shell link information.</param>
        /// <returns><c>true</c> if creating the specified shell link successfully, <c>false</c> otherwise.</returns>
        public bool Create(ShellLinkInfo shellLinkInfo)
        {
            if (shellLinkInfo == null)
            {
                return false;
            }

            var result = false;
            try
            {
                result = OnCreate(shellLinkInfo);
            }
            catch (Exception e)
            {
                Logger.GetInstance(typeof(LinkManager)).Error(e.ToString());
            }
            return result;
        }

        /// <summary>
        /// Called when creating the specified file link.
        /// </summary>
        /// <param name="fileLinkInfo">The file link information.</param>
        /// <returns><c>true</c> if creating the specified file link successfully, <c>false</c> otherwise.</returns>
        protected abstract bool OnCreate(FileLinkInfo fileLinkInfo);
        /// <summary>
        /// Called when creating the specified shell link.
        /// </summary>
        /// <param name="shellLinkInfo">The shell link information.</param>
        /// <returns><c>true</c> if creating the specified shell link successfully, <c>false</c> otherwise.</returns>
        protected abstract bool OnCreate(ShellLinkInfo shellLinkInfo);
    }
}
