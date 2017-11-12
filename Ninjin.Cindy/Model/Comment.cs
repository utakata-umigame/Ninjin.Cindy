namespace Ninjin.Cindy.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Mondai Mondai { get; set; }
        public User Sender { get; set; }
        public override string ToString()
        {
            return string.Format("{0}:{1}",Id,Content);
        }
    }
}
