using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UdemyNET7Learn.Models;


namespace UdemyNET7Learn.Utility
{
    public class UdemyAppDbContext : IdentityDbContext
    {
        public UdemyAppDbContext(DbContextOptions<UdemyAppDbContext> options) : base(options)
        {

        }
        public DbSet<KitapTuru> KitapTurleri { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kiralama> Kiralamalar { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
