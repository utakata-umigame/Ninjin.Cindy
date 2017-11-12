using System.Collections.Generic;
using System.Net;
using System.Linq;

using Newtonsoft.Json;//Json.NET
using Ninjin.Cindy.Model;//Model

namespace Ninjin.Cindy
{
    /// <summary>
    /// a class to fetch Mondai list
    /// </summary>
    public class MondaiListClient:ListClient
    {
        /// <summary>
        /// private constructor
        /// </summary>
        private MondaiListClient()
        {
            Objects = new List<object>();
            DownloadStringCompleted += MondaiListResponse_DownloadStringCompleted;
        }
        protected override string endPoint
        {
            get
            {
                return "http://heyrict.pythonanywhere.com/api/mondai_list";
            }
        }

        /// <summary>
        /// Return Empty Response
        /// </summary>
        /// <returns></returns>
        public static MondaiListClient Empty()
        {
            return new MondaiListClient();
        }
        public static MondaiListClient FetchData()
        {
            var res = new MondaiListClient();
            res.Fetch();
            return res;
        }
        /// <summary>
        /// Use API asyncronously
        /// </summary>
        /// <returns></returns>
        public static MondaiListClient FetchDataAsync()
        {
            var res = new MondaiListClient();
            res.StartFetch();
            return res;
        }
       
        /// <summary>
        /// callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MondaiListResponse_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Parse(e.Result);
            Load();
        }
        /// <summary>
        /// create mondai list based on raw json response.
        /// </summary>
        /// <param name="rawRes"></param>
        protected override void Parse(string rawRes)
        {
            dynamic obj = JsonConvert.DeserializeObject(rawRes);
            var res = (IEnumerable<object>)obj.data;//This step depends on Json format.
            Objects.AddRange(res.Select(x => Mondai.FromJSON(x)));
        }
    }
}
