namespace Ninjin.Cindy.Model
{
    /// <summary>
    /// User Model
    /// </summary>
    public class User
    {
        /// <summary>
        /// private constructor
        /// </summary>
        private User()
        {

        }
        public static User FromJSON(dynamic obj)
        {
            return new User()
            {
            };
        }
    }
}
