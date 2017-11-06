using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ninjin.Cindy.Model
{
    /// <summary>
    /// Mondai model
    /// </summary>
    public class Mondai
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Sender { get; set; }
        public int SenderId { get; set; }
        public bool Yami { get; set; }
        public double Score { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
