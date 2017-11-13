namespace Ninjin.Cindy.Model
{
    /// <summary>
    /// User Model
    /// </summary>
    public class User:CindyModel
    {
        public User()
        {

        }
        public override CindyModel FromJSON(dynamic obj)
        {
            return new User();
        }
    }
}
