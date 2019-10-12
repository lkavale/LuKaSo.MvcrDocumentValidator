using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuKaSo.MvcrDocumentValidator.Extensions
{
    internal static class UriExtensions
    {
        /// <summary>
        /// Attach url ecoded parameters to address
        /// </summary>
        /// <param name="uri">Uri</param>
        /// <param name="parameters">Params to add</param>
        /// <returns></returns>
        public static Uri AttachQueryParameters(this Uri uri, IReadOnlyDictionary<string, string> parameters)
        {
            var queryVars = HttpUtility.ParseQueryString(uri.Query);

            foreach (var kpv in parameters)
            {
                if (queryVars.AllKeys.Contains(kpv.Key))
                {
                    queryVars.Set(kpv.Key, kpv.Value);
                    continue;
                }

                queryVars.Add(kpv.Key, kpv.Value);
            }

            if (queryVars.Count > 0)
            {
                uri = new Uri(uri.GetLeftPart(UriPartial.Path) + "?" + queryVars.ToString());
            }

            return uri;
        }
    }
}
