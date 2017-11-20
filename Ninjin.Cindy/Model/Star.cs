using System;

namespace Ninjin.Cindy.Model
{
    /// <summary>
    /// Star model
    /// </summary>
    public class Star:CindyModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Star()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public static readonly string CsvHeader = "Id,Mondai-Id,Mondai-Title,Value\n";
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// value
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// mondai_id
        /// </summary>
        public Mondai Mondai { get; set; }
        /// <summary>
        /// user_id
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Override FromJSON
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override CindyModel FromJSON(dynamic obj)
        {
            return new Star()
            {
                Id=obj.id,
                Value=obj.value,
                Mondai= CindyModel.FromJSON(obj.mondai_id, ModelType.Mondai)
            };
        }
        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}\n",Id,Mondai.Id,Mondai.Title,Value);
        }
        /// <summary>
        /// override ToTSVString
        /// </summary>
        /// <returns></returns>
        public override string ToTSVString()
        {
            throw new NotImplementedException();
        }
    }
}
