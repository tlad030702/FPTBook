using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FPTBook.Models;

namespace FPTBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<RequestBook> RequestBooks { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    SeedCate(builder);

        //}
        //private void SeedCate(ModelBuilder builder)
        //{
        //    builder.Entity<Categories>().HasData(
        //        new Categories
        //        {
        //            CategoryId = 1,
        //            CategoryName = "Action",
        //            CategoryDescription = "Action"
        //        },
        //        new Categories
        //        {
        //            CategoryId = 2,
        //            CategoryName = "Action",
        //            CategoryDescription = "Action"
        //        },
        //        new Categories
        //        {
        //            CategoryId = 3,
        //            CategoryName = "Action",
        //            CategoryDescription = "Action"
        //        });
        //}
    }
}