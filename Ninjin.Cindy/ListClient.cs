using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ninjin.Cindy.Model;
using System.Net.Http;

namespace Ninjin.Cindy
{
    public class ListClient:HttpClient
    {
        public ListClient()
        { 
            Objects = new List<CindyModel>();
            //DownloadStringCompleted += ListClient_DownloadStringCompleted;
        }
        
        const string mondaiListEndPoint = "http://heyrict.pythonanywhere.com/api/mondai_list";
        const string commentListEndPoint = "http://heyrict.pythonanywhere.com/api/comment";
        const string userListEndPoint = "http://heyrict.pythonanywhere.com/api/";
        const string starListEndPoint = "http://heyrict.pythonanywhere.com/api/star";
        /// <summary>
        /// Type of model
        /// </summary>
        public ModelType ModelType { get; private set; }
        /// <summary>
        /// Endpoint
        /// </summary>
        public string EndPoint { get; private set; }
        /// <summary>
        /// List of objects
        /// </summary>
        public List<CindyModel> Objects{ get;}
        /// <summary>
        /// Fetch Object list
        /// </summary>
        public void FetchData(ModelType type)
        {
            EndPoint = SelectEndPoint(type);
            if (EndPoint == null)
            {
                throw new ArgumentNullException("no endpoint specified.");
            }
        }
        public async Task FetchDataAsync(ModelType type)
        {
            await Task.Run(()=>
            {
                EndPoint = SelectEndPoint(type);
                var res = GetStringAsync(new Uri(EndPoint));
                Parse(res.Result, type);
            });
        }
        /// <summary>
        /// create object list based on raw json response.
        /// to be implemented in inherited class.
        /// /summary>
        /// <param name="rawRes"></param>
        private void Parse(string rawRes, ModelType type)
        {
            dynamic obj = JsonConvert.DeserializeObject(rawRes);
            var res = (IEnumerable<object>)obj.data;//This step depends on Json format.
            Objects.AddRange(res.Select(x => CindyModel.FromJSON(x, type)));
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
