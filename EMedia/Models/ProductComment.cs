namespace EMedia.Models
{
    public class ProductComment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        public string UserId { get; set; } //kimin yorum yaptıgının bilgisini tuttuk

        // public bool IsActive { get; set; } //yorum Aktif Mi

        // public bool IsApproved { get; set; } //eğer onaylandıysa 1, reddedildiyse 0

        public int IsApproved { get; set; }  //yeni eklenenler 0, onaylananlar 1, reddedilenler 2

        public int Point { get; set; } //urune kullanıcı tarafından verilen puan bilgisi

        public DateOnly CreatedDate { get; set; } //urune yorum yapılma zamanını tutacak
    }
}
