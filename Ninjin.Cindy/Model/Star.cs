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
        /// Override FromJSON
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override CindyModel FromJSON(dynamic obj)
        {
            return new Star()
            {
            };
        }
    }
}
