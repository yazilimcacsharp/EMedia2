using EMedia.Models;
using Microsoft.EntityFrameworkCore;

namespace EMedia.Data
{
    public class ArtDBContext : DbContext
    {
        //tablolar-classlar buraya tanımlanır.

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }

        public ArtDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //alttakiler dataSeed için eklendi.(Katalog Datası)

            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Müzik", IsActive = true },
            new Category { Id = 2, Name = "Film", IsActive = true },
            new Category { Id = 3, Name = "Tiyatro", IsActive = true },
            new Category { Id = 4, Name = "Konser", IsActive = true });

            //Pop-Rock-Jazz-Blues-Klasik-Metal-Reggae
            //Aksiyon-Dram-Komedi
            //Trajedi-Komedi-Dram-Müzikli Tiyatro
            //Klasik Müzik Konserleri-Halk Müziği Konserleri-Akustik Konserler


            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory { Id = 1, Name = "Pop", CategoryId = 1, IsActive = true },
                new SubCategory { Id = 2, Name = "Rock", CategoryId = 1, IsActive = true },
                new SubCategory { Id = 3, Name = "Jazz", CategoryId = 1, IsActive = true },
                new SubCategory { Id = 4, Name = "Blues", CategoryId = 1, IsActive = true },
                new SubCategory { Id = 5, Name = "Klasik", CategoryId = 1, IsActive = true },
                new SubCategory { Id = 6, Name = "Metal", CategoryId = 1, IsActive = true },
                new SubCategory { Id = 7, Name = "Reggae", CategoryId = 1, IsActive = true },

                new SubCategory { Id = 8, Name = "Aksiyon", CategoryId = 2, IsActive = true },
                new SubCategory { Id = 9, Name = "Dram", CategoryId = 2, IsActive = true },
                new SubCategory { Id = 10, Name = "Komedi", CategoryId = 2, IsActive = true },

                new SubCategory { Id = 11, Name = "Trajedi", CategoryId = 3, IsActive = true },
                new SubCategory { Id = 12, Name = "Komedi", CategoryId = 3, IsActive = true },
                new SubCategory { Id = 13, Name = "Dram", CategoryId = 3, IsActive = true },
                new SubCategory { Id = 14, Name = "Müzikli Tiyatro", CategoryId = 3, IsActive = true },

                new SubCategory { Id = 15, Name = "Klasik Müzik Konserleri", CategoryId = 4, IsActive = true },
                new SubCategory { Id = 16, Name = "Halk Müziği Konserleri", CategoryId = 4, IsActive = true },
                new SubCategory { Id = 17, Name = "Akustik Konserler", CategoryId = 4, IsActive = true },
                  new SubCategory { Id = 18, Name = "Pop Konserleri", CategoryId = 4, IsActive = true },
        new SubCategory { Id = 19, Name = "Rock Konserleri", CategoryId = 4, IsActive = true },
        new SubCategory { Id = 20, Name = "Jazz Konserleri", CategoryId = 4, IsActive = true }

                );



            modelBuilder.Entity<Product>().HasData(
    new Product
    {
        Id = 1,
        Name = "Pop Albümü - Greatest Hits",
        SubCategoryId = 1, // Pop
        IsActive = true,
        Price = 49.90m,
        CreatedDate = DateTime.Now,
        Stock = 100,
        FotoPath = "images/pop_album.jpg"
    },
    new Product
    {
        Id = 2,
        Name = "Rock Albümü - Legends of Rock",
        SubCategoryId = 2, // Rock
        IsActive = true,
        Price = 59.90m,
        CreatedDate = DateTime.Now,
        Stock = 80,
        FotoPath = "images/rock_album.jpg"
    },
    new Product
    {
        Id = 3,
        Name = "Jazz Albümü - Smooth Jazz Collection",
        SubCategoryId = 3, // Jazz
        IsActive = true,
        Price = 39.90m,
        CreatedDate = DateTime.Now,
        Stock = 60,
        FotoPath = "images/jazz_album.jpg"
    },
    new Product
    {
        Id = 4,
        Name = "Blues Albümü - Soulful Blues",
        SubCategoryId = 4, // Blues
        IsActive = true,
        Price = 44.90m,
        CreatedDate = DateTime.Now,
        Stock = 50,
        FotoPath = "images/blues_album.jpg"
    },
    new Product
    {
        Id = 5,
        Name = "Klasik Albüm - Mozart Collection",
        SubCategoryId = 5, // Klasik
        IsActive = true,
        Price = 69.90m,
        CreatedDate = DateTime.Now,
        Stock = 40,
        FotoPath = "images/classical_album.jpg"
    },
    new Product
    {
        Id = 6,
        Name = "Metal Albümü - Heavy Metal Anthems",
        SubCategoryId = 6, // Metal
        IsActive = true,
        Price = 54.90m,
        CreatedDate = DateTime.Now,
        Stock = 70,
        FotoPath = "images/metal_album.jpg"
    },
    new Product
    {
        Id = 7,
        Name = "Reggae Albümü - Bob Marley Tribute",
        SubCategoryId = 7, // Reggae
        IsActive = true,
        Price = 42.90m,
        CreatedDate = DateTime.Now,
        Stock = 90,
        FotoPath = "images/reggae_album.jpg"
    },

      new Product
      {
          Id = 8,
          Name = "Aksiyon Filmi - Mad Max: Fury Road",
          SubCategoryId = 8, // Aksiyon
          IsActive = true,
          Price = 89.90m,
          CreatedDate = DateTime.Now,
          Stock = 120,
          FotoPath = "images/action_madmax.jpg"
      },
    new Product
    {
        Id = 9,
        Name = "Aksiyon Filmi - John Wick",
        SubCategoryId = 8, // Aksiyon
        IsActive = true,
        Price = 79.90m,
        CreatedDate = DateTime.Now,
        Stock = 100,
        FotoPath = "images/action_johnwick.jpg"
    },
    new Product
    {
        Id = 10,
        Name = "Dram Filmi - The Shawshank Redemption",
        SubCategoryId = 9, // Dram
        IsActive = true,
        Price = 69.90m,
        CreatedDate = DateTime.Now,
        Stock = 80,
        FotoPath = "images/drama_shawshank.jpg"
    },
    new Product
    {
        Id = 11,
        Name = "Dram Filmi - Forrest Gump",
        SubCategoryId = 9, // Dram
        IsActive = true,
        Price = 74.90m,
        CreatedDate = DateTime.Now,
        Stock = 90,
        FotoPath = "images/drama_forrestgump.jpg"
    },
    new Product
    {
        Id = 12,
        Name = "Komedi Filmi - The Mask",
        SubCategoryId = 10, // Komedi
        IsActive = true,
        Price = 59.90m,
        CreatedDate = DateTime.Now,
        Stock = 110,
        FotoPath = "images/comedy_mask.jpg"
    },
    new Product
    {
        Id = 13,
        Name = "Komedi Filmi - Home Alone",
        SubCategoryId = 10, // Komedi
        IsActive = true,
        Price = 64.90m,
        CreatedDate = DateTime.Now,
        Stock = 130,
        FotoPath = "images/comedy_homealone.jpg"
    },

     new Product
     {
         Id = 14,
         Name = "Trajedi Oyunu - Kral Oidipus",
         SubCategoryId = 11, // Trajedi
         IsActive = true,
         Price = 99.90m,
         CreatedDate = DateTime.Now,
         Stock = 50,
         FotoPath = "images/tiyatro_trajedi_oidipus.jpg"
     },
    new Product
    {
        Id = 15,
        Name = "Komedi Oyunu - Bir Yaz Gecesi Rüyası",
        SubCategoryId = 12, // Komedi
        IsActive = true,
        Price = 79.90m,
        CreatedDate = DateTime.Now,
        Stock = 70,
        FotoPath = "images/tiyatro_komedi_yazgecesi.jpg"
    },
    new Product
    {
        Id = 16,
        Name = "Dram Oyunu - Hamlet",
        SubCategoryId = 13, // Dram
        IsActive = true,
        Price = 89.90m,
        CreatedDate = DateTime.Now,
        Stock = 60,
        FotoPath = "images/tiyatro_dram_hamlet.jpg"
    },
    new Product
    {
        Id = 17,
        Name = "Müzikli Tiyatro - Les Misérables",
        SubCategoryId = 14, // Müzikli Tiyatro
        IsActive = true,
        Price = 119.90m,
        CreatedDate = DateTime.Now,
        Stock = 40,
        FotoPath = "images/tiyatro_muzikli_lesmis.jpg"
    }
);
        }
    }
}
