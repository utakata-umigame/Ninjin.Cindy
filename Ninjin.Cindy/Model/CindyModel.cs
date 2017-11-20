using System;

namespace Ninjin.Cindy.Model
{
    /// <summary>
    /// Types of models
    /// </summary>
    public enum ModelType
    {
        /// <summary>
        /// mondai
        /// </summary>
        Mondai,
        /// <summary>
        /// user
        /// </summary>
        User,
        /// <summary>
        /// comment
        /// </summary>
        Comment,
        /// <summary>
        /// star
        /// </summary>
        Star
    }
    /// <summary>
    /// Abstract model
    /// </summary>
    public abstract class CindyModel
    {
        /// <summary>
        /// Create an instance of subclass
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static CindyModel FromJSON(dynamic obj, ModelType type)
        {
            //static factory method
            switch (type)
            {
                case ModelType.Mondai:
                    return new Mondai().FromJSON(obj);
                case ModelType.User:
                    return new User().FromJSON(obj);
                case ModelType.Comment:
                    return new Comment().FromJSON(obj);
                case ModelType.Star:
                    return new Star().FromJSON(obj);
                default:
                    throw new ArgumentException();
            }
        }
        /// <summary>
        /// Create an instance from Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract CindyModel FromJSON(dynamic obj);

        /// <summary>
        /// Convert to TSV string
        /// </summary>
        /// <returns></returns>
        public abstract string ToTSVString();
    }
}
