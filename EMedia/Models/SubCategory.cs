namespace EMedia.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Product> Products { get; set; } //1 alt kategoride 1den fazla ürün olabileceği için çoğul tanımlama yaptık. 
    }
}
