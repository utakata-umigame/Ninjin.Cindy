using System.Collections.Generic;
using System.Linq;

using System.Net; //webclient
using Newtonsoft.Json; //json.NET
using Ninjin.Cindy.Model;


namespace Ninjin.Cindy
{
    public class CommentListClient:ListClient
    {
        /// <summary>
        /// private constructor
        /// </summary>
        private CommentListClient()
        {
            Objects = new List<object>();
            DownloadStringCompleted += CommentListClient_DownloadStringCompleted;
        }

        private void CommentListClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Parse(e.Result);
            Load();
        }

        /// <summary>
        /// Return Empty Response
        /// </summary>
        /// <returns></returns>
        public static CommentListClient Empty()
        {
            return new CommentListClient();
        }
        public static CommentListClient FetchData()
        {
            var res = new CommentListClient();
            res.Fetch();
            return res;
        }
        /// <summary>
        /// Use API asyncronously
        /// </summary>
        /// <returns></returns>
        public static ListClient FetchDataAsync()
        {
            var res = new CommentListClient();
            res.StartFetch();
            return res;
        }
        protected override string endPoint
        {
            get
            {
                return "http://heyrict.pythonanywhere.com/api/comment";
            }
        }
        protected override void Parse(string rawRes)
        {
            dynamic obj = JsonConvert.DeserializeObject(rawRes);
            var res = (IEnumerable<object>)obj.data;//This step depends on Json format.
            Objects.AddRange(res.Select(x => Comment.FromJSON(x)));
        }

    }
}
