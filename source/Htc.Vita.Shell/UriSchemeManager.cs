using System;
using System.Collections.Generic;
using System.Linq;
using Htc.Vita.Core.Log;
using Htc.Vita.Core.Util;

namespace Htc.Vita.Shell
{
    /// <summary>
    /// Class UriSchemeManager.
    /// </summary>
    public abstract partial class UriSchemeManager
    {
        /// <summary>
        /// The option is used to accept whitelist only
        /// </summary>
        public static readonly string OptionAcceptWhitelistOnly = "option_accept_whitelist_only";

        /// <summary>
        /// Initializes static members of the <see cref="UriSchemeManager"/> class.
        /// </summary>
        static UriSchemeManager()
        {
            TypeRegistry.RegisterDefault<UriSchemeManager, DefaultUriSchemeManager>();
        }

        /// <summary>
        /// Registers the instance type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Register<T>()
                where T : UriSchemeManager, new()
        {
            TypeRegistry.Register<UriSchemeManager, T>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>UriSchemeManager.</returns>
        public static UriSchemeManager GetInstance()
        {
            return TypeRegistry.GetInstance<UriSchemeManager>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>UriSchemeManager.</returns>
        public static UriSchemeManager GetInstance<T>()
                where T : UriSchemeManager, new()
        {
            return TypeRegistry.GetInstance<UriSchemeManager, T>();
        }

        /// <summary>
        /// Gets the system URI scheme.
        /// </summary>
        /// <param name="schemeName">The scheme name.</param>
        /// <returns>GetUriSchemeResult.</returns>
        public GetUriSchemeResult GetSystemUriScheme(string schemeName)
        {
            return GetSystemUriScheme(
                    schemeName,
                    null
            );
        }

        /// <summary>
        /// Gets the system URI scheme.
        /// </summary>
        /// <param name="schemeName">The scheme name.</param>
        /// <param name="options">The options.</param>
        /// <returns>GetUriSchemeResult.</returns>
        public GetUriSchemeResult GetSystemUriScheme(
                string schemeName,
                Dictionary<string, string> options)
        {
            if (!schemeName.All(c => char.IsLetterOrDigit(c) || c == '+' || c == '-' || c == '.'))
            {
                Logger.GetInstance(typeof(UriSchemeManager)).Error($"Do not find valid scheme name: \"{schemeName}\"");
                return new GetUriSchemeResult
                {
                        Status = GetUriSchemeStatus.InvalidData
                };
            }

            var realOptions = options ?? new Dictionary<string, string>();
            GetUriSchemeResult result = null;
            try
            {
                result = OnGetSystemUriScheme(
                        schemeName,
                        realOptions
                );
            }
            catch (Exception e)
            {
                Logger.GetInstance(typeof(UriSchemeManager)).Error($"Can not get system uri scheme: {e.Message}");
            }

            return result ?? new GetUriSchemeResult();
        }

        /// <summary>
        /// Called when getting system URI scheme.
        /// </summary>
        /// <param name="schemeName">The scheme name.</param>
        /// <param name="options">The options.</param>
        /// <returns>GetUriSchemeResult.</returns>
        protected abstract GetUriSchemeResult OnGetSystemUriScheme(
                string schemeName,
                Dictionary<string, string> options
        );
    }
}
