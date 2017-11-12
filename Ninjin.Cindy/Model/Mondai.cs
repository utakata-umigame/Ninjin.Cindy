using System;

namespace Ninjin.Cindy.Model
{
    /// <summary>
    /// Mondai model
    /// </summary>
    public class Mondai
    {
        private Mondai()
        {

        }
        public static Mondai FromJSON(dynamic obj)
        {
            try
            {
                return new Mondai()
                {
                    Id = obj.id,
                    Title = obj.title,
                    Sender = obj.user_id.nickname,
                    SenderId = obj.user_id.id,
                    Yami = obj.yami,
                    Score = obj.score,
                    GiverExperience = obj.user_id.experience
                };
            }
            catch
            {
                throw new ArgumentException("Invalid type");
            }
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Sender { get; set; }
        public int SenderId { get; set; }
        public bool Yami { get; set; }
        public double Score { get; set; }
        public User Giver { get; set; }
        public int GiverExperience { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
