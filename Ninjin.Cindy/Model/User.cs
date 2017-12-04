using System;

namespace Ninjin.Cindy.Model
{
    /// <summary>
    /// User Model
    /// </summary>
    public class User:CindyModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public User()
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
                return new User()
                {
                    Id = obj.id,
                    Nickname=obj.nickname,
                    UserName=obj.username,
                    Experience = obj.experience
                };
            }
            catch
            {
                throw new ArgumentException("Invalid type");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static readonly string CsvHeader = "Id,Nickname,UserName,Experience\n";
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nickname
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// username
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// experience
        /// </summary>
        public int Experience { get; set; }
        /// <summary>
        /// override ToTSCString
        /// </summary>
        /// <returns></returns>
        public override string ToTSVString()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// tocsvstring
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}\n",Id,Nickname,UserName,Experience);
        }
    }
}
