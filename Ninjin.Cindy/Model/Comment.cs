using System;

namespace Ninjin.Cindy.Model
{
    public class Comment:CindyModel
    {
        public Comment()
        {

        }
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
        public static readonly string CsvHeader = "Id,Sender-Name,Mondai-Id,Mondai-Title,Comment\n";
        public int Id { get; set; }
        public string Content { get; set; }
        public string SenderName { get; set; }
        public Mondai Mondai { get; set; }
        public User Sender { get; set; }
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}\n",Id,SenderName,Mondai.Id,Mondai.Title,Content);
        }
    }
}
