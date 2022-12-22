using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FPTBook.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace FPTBook.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
               .Property(e => e.FullName)
            .HasMaxLength(250);

            builder.Entity<ApplicationUser>()
                .Property(e => e.Address)
                .HasMaxLength(250);

            

            //add dữ liệu cho bảng User
            SeedUser(builder);

            //add dữ liệu cho bảng Role
            SeedRole(builder);

            //add dữ liệu cho bảng UserRole
            SeedUserRole(builder);
        }

        private void SeedUser(ModelBuilder builder)
        {
            //1. tạo tài khoản ban đầu để add vào DB
            var admin = new ApplicationUser
            { 
                Id = "1",
                FullName= "Duy Duong",
                Address = "Ha noi",
                UserName = "admin@fpt.com",
                Email = "admin@fpt.com",
                NormalizedUserName = "admin@fpt.com",
                EmailConfirmed = true,
            };

            var customer = new ApplicationUser
            {
                Id = "2",
                FullName = "Minh Duc",
                Address = "Ha noi",
                UserName = "customer@fpt.com",
                Email = "customer@fpt.com",
                NormalizedUserName = "customer@fpt.com",
                EmailConfirmed = true,
                
            };

            var staff = new ApplicationUser
            {
                Id = "3",
                FullName = "Toan Duc",
                Address = "Ha noi",
                UserName = "Staff@fpt.com",
                Email = "Staff@fpt.com",
                NormalizedUserName = "Staff@fpt.com",
                EmailConfirmed = true,
            };

            //2. khai báo thư viện để mã hóa mật khẩu
            var hasher = new PasswordHasher<ApplicationUser>();

            //3. thiết lập và mã hóa mật khẩu   từng tài khoản
            admin.PasswordHash = hasher.HashPassword(admin, "P@ssW0rd!");
            customer.PasswordHash = hasher.HashPassword(customer, "P@ssW0rd!");
            staff.PasswordHash = hasher.HashPassword(staff, "P@ssW0rd!");

            //4. add tài khoản vào db
            builder.Entity<ApplicationUser>().HasData(admin, customer, staff);
        }

        private void SeedRole(ModelBuilder builder)
        {
            //1. tạo các role cho hệ thống
            var admin = new IdentityRole
            {
                Id = "A",
                Name = "Administrator",
                NormalizedName = "Administrator"
            };
            var customer = new IdentityRole
            {
                Id = "B",
                Name = "Customer",
                NormalizedName = "Customer"
            };
            var staff = new IdentityRole
            {
                Id = "C",
                Name = "Staff",
                NormalizedName = "Staff"
            };

            //2. add role vào trong DB
            builder.Entity<IdentityRole>().HasData(admin, customer , staff);

        }

        private void SeedUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "A"
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "B"
                }
             );
        }
    }
}