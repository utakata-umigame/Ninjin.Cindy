using System;
using System.Collections.Generic;
using System.Linq;

using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Ninjin.Cindy.Model;

namespace Ninjin.Cindy
{
    public class ListClient:WebClient
    {
        public ListClient(ModelType type)
        {
            ModelType = type;
            EndPoint = SelectEndPoint(type);
            Objects = new List<CindyModel>();
            DownloadStringCompleted += ListClient_DownloadStringCompleted;
        }

        
        const string mondaiListEndPoint = "http://heyrict.pythonanywhere.com/api/mondai_list";
        const string commentListEndPoint = "http://heyrict.pythonanywhere.com/api/comment";
        const string userListEndPoint = "http://heyrict.pythonanywhere.com/api/";
        const string starListEndPoint = "http://heyrict.pythonanywhere.com/api/star";
        public ModelType ModelType { get; private set; }
        public string EndPoint { get; }
        public Action Load = delegate { };
        public List<CindyModel> Objects{ get;}
        /// <summary>
        /// Fetch Object list
        /// </summary>
        public void Fetch()
        {
            if (EndPoint == null)
            {
                throw new ArgumentNullException("no endpoint specified.");
            }
            var result = Regex.Unescape(DownloadString(new Uri(EndPoint)));
            Parse(result);
        }
        public void FetchDataAsync()
        {
            DownloadStringAsync(new Uri(EndPoint));
        }
        /// <summary>
        /// callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Parse(e.Result);
            Load();
        }
        /// <summary>
        /// create object list based on raw json response.
        /// to be implemented in inherited class.
        /// /summary>
        /// <param name="rawRes"></param>
        private void Parse(string rawRes)
        {
            dynamic obj = JsonConvert.DeserializeObject(rawRes);
            var res = (IEnumerable<object>)obj.data;//This step depends on Json format.
            Objects.AddRange(res.Select(x => CindyModel.FromJSON(x, ModelType)));
        }
        /// <summary>
        /// Convert type into endpoint
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string SelectEndPoint(ModelType type)
        {
            switch (type)
            {
                case ModelType.Mondai:
                    return mondaiListEndPoint;
                case ModelType.User:
                    return userListEndPoint;
                case ModelType.Comment:
                    return commentListEndPoint;
                case ModelType.Star:
                    return starListEndPoint;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
