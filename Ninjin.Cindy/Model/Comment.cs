using System;

namespace Ninjin.Cindy.Model
{
    /// <summary>
    /// Comment model
    /// </summary>
    public class Comment:CindyModel
    {
        /// <summary>
        /// Empty
        /// </summary>
        public Comment()
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
                return new Comment()
                {
                    Id = obj.id,
                    Content = obj.content,
                    SenderName = obj.user_id.nickname,
                    Mondai = CindyModel.FromJSON(obj.mondai_id, ModelType.Mondai)
                };
            }
            catch
            {
                throw new ArgumentException("Invalid type");
            }
        }
        /// <summary>
        /// Header
        /// </summary>
        public static readonly string CsvHeader = "Id,Sender-Name,Mondai-Id,Mondai-Title,Comment\n";
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// user_id.nickname
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// mondai_id
        /// </summary>
        public Mondai Mondai { get; set; }
        /// <summary>
        /// user_id
        /// </summary>
        public User Sender { get; set; }
        /// <summary>
        /// Override ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}\n",Id,SenderName,Mondai.Id,Mondai.Title,Content);
        }
    }
}
