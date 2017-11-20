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
            return new User();
        }
        /// <summary>
        /// override ToTSCString
        /// </summary>
        /// <returns></returns>
        public override string ToTSVString()
        {
            throw new NotImplementedException();
        }
    }
}
