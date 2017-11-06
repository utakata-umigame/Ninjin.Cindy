using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

using Ninjin.Cindy.Model;

namespace Ninjin.Cindy
{
    /// <summary>
    /// a class to fetch Mondai list
    /// </summary>
    public class MondaiListResponse:WebClient
    {
        /// <summary>
        /// private constructor
        /// </summary>
        private MondaiListResponse()
        {
            Mondais = new List<Mondai>();
        }
        /// <summary>
        /// Return Empty Response
        /// </summary>
        /// <returns></returns>
        public static MondaiListResponse Empty()
        {
            return new MondaiListResponse();
        }
        /// <summary>
        /// Use API
        /// </summary>
        /// <returns></returns>
        public static MondaiListResponse FetchData()
        {
            var res = new MondaiListResponse();
            res.Fetch();
            return res;
        }
        /// <summary>
        /// Endpoint url
        /// </summary>
        static readonly string endPoint = "http://heyrict.pythonanywhere.com/api/mondai_list";
        public List<Mondai> Mondais { get; }
        /// <summary>
        /// Fetch Mondai list
        /// </summary>
        /// <returns>list of mondai</returns>
        private void Fetch()
        {
            var result = Regex.Unescape(DownloadString(new Uri(endPoint)));
            dynamic obj = JsonConvert.DeserializeObject(result);
            var res = obj.data.others;
            foreach (var item in res)
            {
                var mondai = new Mondai()
                {
                    Id = item.id,
                    Title = item.title,
                    Sender = item.user_id.nickname,
                    SenderId = item.user_id.id,
                    Yami = item.yami,
                    Score = item.score
                };
                Mondais.Add(mondai);
            }
        }
    }
}
