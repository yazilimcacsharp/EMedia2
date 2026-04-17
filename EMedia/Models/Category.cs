namespace EMedia.Models
{
    public class Category
    {
        // (müzik, film ,tiyatro, konser)
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } //ilerde kategoriyi silmek için
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
