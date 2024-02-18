using Angularapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Angularapi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-L9MOUD6;Database=Angular;Trusted_Connection=True;MultipleActiveResultSets=true");
        //    }
        //}
        //public DbSet<PRODUCT> Products { get; set; }
        //public DbSet<CATEGORY> Categories { get; set; }
    }
}
