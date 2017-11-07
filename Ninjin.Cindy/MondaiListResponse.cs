using System;
using System.Collections.Generic;
using System.Net;

using Newtonsoft.Json;//Json.NET
using System.Text.RegularExpressions;//Regex

using Ninjin.Cindy.Model;//Model

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
            DownloadStringCompleted += MondaiListResponse_DownloadStringCompleted;
        }
        /// <summary>
        /// Return Empty Response
        /// </summary>
        /// <returns></returns>
        public static MondaiListResponse Empty()
        {
            return new MondaiListResponse();
        }
        public static MondaiListResponse FetchData()
        {
            var res = new MondaiListResponse();
            res.Fetch();
            return res;
        }
        /// <summary>
        /// Use API asyncronously
        /// </summary>
        /// <returns></returns>
        public static MondaiListResponse FetchDataAsync()
        {
            var res = new MondaiListResponse();
            res.StartFetch();
            return res;
        }
        /// <summary>
        /// Endpoint url
        /// </summary>
        static readonly string endPoint = "http://heyrict.pythonanywhere.com/api/mondai_list";
        public event Action DownloadCompleted = delegate { };
        /// <summary>
        /// Mondai list
        /// </summary>
        public List<Mondai> Mondais { get; }
        /// <summary>
        /// Fetch Mondai list
        /// </summary>
        /// <returns>list of mondai</returns>
        private void Fetch()
        {
            var result = Regex.Unescape(DownloadString(new Uri(endPoint)));
            Parse(result);
        }
        private void StartFetch()
        {
            DownloadStringAsync(new Uri(endPoint));
        }
        /// <summary>
        /// callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MondaiListResponse_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Parse(e.Result);
            DownloadCompleted();
        }
        /// <summary>
        /// create mondai list based on raw json response.
        /// </summary>
        /// <param name="rawRes"></param>
        private void Parse(string rawRes)
        {
            dynamic obj = JsonConvert.DeserializeObject(rawRes);
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
