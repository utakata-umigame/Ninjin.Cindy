namespace Ninjin.Cindy.Model
{
    public class Star:CindyModel
    {
        /// <summary>
        /// private constructor
        /// </summary>
        public Star()
        {

        }
        public override CindyModel FromJSON(dynamic obj)
        {
            return new Star()
            {
            };
        }
    }
}
