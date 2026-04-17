using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMedia.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    var hasher = new PasswordHasher<IdentityUser>();
        //    var user = new IdentityUser
        //    {
        //        Id = "b74ddd14-6340-4840-95c2-db12554843e5", // sabit GUID
        //        UserName = "n@gmail.com",
        //        NormalizedUserName = "N@GMAIL.COM",
        //        Email = "n@gmail.com",
        //        NormalizedEmail = "N@GMAIL.COM",
        //        EmailConfirmed = true,
        //        SecurityStamp = "f2f5c2f0-3f3c-4a7a-9a7f-123456789abc" // sabit değer
        //    };

        //    user.PasswordHash = hasher.HashPassword(user, "User123!");

        //    modelBuilder.Entity<IdentityUser>().HasData(user);
        //}

    }
}
