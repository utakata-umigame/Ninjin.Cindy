using System;
using System.Collections.Generic;

using System.Net;
using System.Text.RegularExpressions;

namespace Ninjin.Cindy
{
    public class ListClient:WebClient
    {
        protected virtual string endPoint
        {
            get { return ""; }
        }

        public Action Load = delegate { };
        public List<object> Objects{ get; protected set; }
        /// <summary>
        /// Fetch Object list
        /// </summary>
        protected void Fetch()
        {
            if (endPoint == null)
            {
                throw new ArgumentNullException("no endpoint specified.");
            }
            var result = Regex.Unescape(DownloadString(new Uri(endPoint)));
            Parse(result);
        }
        protected void StartFetch()
        {
            DownloadStringAsync(new Uri(endPoint));
        }
        /// <summary>
        /// create object list based on raw json response.
        /// to be implemented in inherited class.
        /// </summary>
        /// <param name="rawRes"></param>
        protected virtual void Parse(string rawRes)
        {
        }
    }
}
