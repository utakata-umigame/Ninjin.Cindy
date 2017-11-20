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
        /// <summary>
        /// Empty
        /// </summary>
        public Mondai()
        {

        }
        /// <summary>
        /// Override FromJSON
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
        /// <summary>
        /// CSV header
        /// </summary>
        public static readonly string CsvHeader = "Id,Genre,Title,Giver-Nickname,Yami,Score\n";
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// user_id.nickname
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// user_id.id
        /// </summary>
        public int SenderId { get; set; }
        /// <summary>
        /// yami
        /// </summary>
        public bool Yami { get; set; }
        /// <summary>
        /// score
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// user_id
        /// </summary>
        public User Giver { get; set; }
        /// <summary>
        /// genre
        /// </summary>
        public Genre Genre { get; set; }
        /// <summary>
        /// expreience
        /// </summary>
        public int GiverExperience { get; set; }
        /// <summary>
        /// Override ToString
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// override ToTSVString
        /// </summary>
        /// <returns></returns>
        public override string ToTSVString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\n",
                                    Id,
                                    Genre,
                                    Title,
                                    Sender,
                                    Yami,
                                    Score);
        }
    }
}
