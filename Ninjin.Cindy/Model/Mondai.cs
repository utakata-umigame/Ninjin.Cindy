using System;
using System.Text.RegularExpressions;

namespace Ninjin.Cindy.Model
{
    /// <summary>
    /// Genre
    /// </summary>
    public enum Genre
    {
        /// <summary>
        /// Albatross
        /// </summary>
        Umigame =0,
        /// <summary>
        /// 20 Doors
        /// </summary>
        Tobira =1,
        /// <summary>
        /// Kameo
        /// </summary>
        Kameo =2,
        /// <summary>
        /// New Genre
        /// </summary>
        Shin =3
    }
    /// <summary>
    /// Mondai model
    /// </summary>
    public class Mondai:CindyModel
    {
        public Mondai()
        {

        }
        public override CindyModel FromJSON(dynamic obj)
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
                    Genre = obj.genre,
                    GiverExperience = obj.user_id.experience
                };
            }
            catch
            {
                throw new ArgumentException("Invalid type");
            }
        }
        public static readonly string CsvHeader = "Id,Genre,Title,Giver-Nickname,Yami,Score\n";
        public int Id { get; set; }
        public string Title { get; set; }
        public string Sender { get; set; }
        public int SenderId { get; set; }
        public bool Yami { get; set; }
        public double Score { get; set; }
        public User Giver { get; set; }
        public Genre Genre { get; set; }
        public int GiverExperience { get; set; }
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}\n", 
                                    Id,
                                    Genre,
                                    Regex.Replace(Title,",","[comma]"), 
                                    Regex.Replace(Sender,",","[comma]"), 
                                    Yami, 
                                    Score);
        }
    }
}
