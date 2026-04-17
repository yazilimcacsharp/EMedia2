namespace EMedia.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }

        public ICollection<ProductComment> ProductComments { get; set; }
    }
}
