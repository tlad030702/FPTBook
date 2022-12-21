using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FPTBook.Models;
using Microsoft.AspNetCore.Identity;

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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Note: add dữ liệu cho bảng chứa PK trước (University)
            //rồi add dữ liệu cho bảng chứa FK sau (Student)

            //add dữ liệu khởi tạo cho bảng University
            //PopulateUniversity(builder);

            //add dữ liệu khởi tạo (initial data) cho bảng Student
            //SeedStudent(builder);

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
            var admin = new IdentityUser
            { 
                Id = "1",
                UserName = "admin@fpt.com",
                Email = "admin@fpt.com",
                NormalizedUserName = "admin@fpt.com",
                EmailConfirmed = true,
            };

            var customer = new IdentityUser
            {
                Id = "2",
                UserName = "customer@fpt.com",
                Email = "customer@fpt.com",
                NormalizedUserName = "customer@fpt.com",
                EmailConfirmed = true,
                
            };

            var staff = new IdentityUser
            {
                Id = "3",
                UserName = "Staff@fpt.com",
                Email = "Staff@fpt.com",
                NormalizedUserName = "Staff@fpt.com",
                EmailConfirmed = true,
            };

            //2. khai báo thư viện để mã hóa mật khẩu
            var hasher = new PasswordHasher<IdentityUser>();

            //3. thiết lập và mã hóa mật khẩu   từng tài khoản
            admin.PasswordHash = hasher.HashPassword(admin, "P@ssW0rd!");
            customer.PasswordHash = hasher.HashPassword(customer, "P@ssW0rd!");
            staff.PasswordHash = hasher.HashPassword(staff, "P@ssW0rd!");

            //4. add tài khoản vào db
            builder.Entity<IdentityUser>().HasData(admin, customer, staff);
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