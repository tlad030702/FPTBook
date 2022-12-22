using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTBook.Migrations
{
    public partial class name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "A", "7d205837-b0a9-40b8-bd0e-677f9aa0fbdb", "Administrator", "Administrator" },
                    { "B", "3258990b-c777-4d3f-be4c-ccd25c110060", "Customer", "Customer" },
                    { "C", "81976675-d3d5-4dc8-9664-72ed3639adb1", "Staff", "Staff" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "91b10d0b-275b-46e4-8614-6fe426386f49", "admin@fpt.com", true, false, null, null, "admin@fpt.com", "AQAAAAEAACcQAAAAEMoRN8Vi/2ETWiKuUgj8Waf4U5IQ1ZgtMZDU7EgO7MQ/vCmiHOpF+r8NfZrbjTbXAw==", null, false, "741be129-9da2-44a6-acdb-6195f7ff240b", false, "admin@fpt.com" },
                    { "2", 0, "c795034c-0528-4851-81d0-46bf15b39964", "customer@fpt.com", true, false, null, null, "customer@fpt.com", "AQAAAAEAACcQAAAAEDCK7PJHOgd8BuSXJNEKeUEcFJonBzixpR2Q60DDG8Ccyqb+4XM/G5PRhJIXFZxcZQ==", null, false, "eb5b99d2-8088-432b-945a-573e54c8f36a", false, "customer@fpt.com" },
                    { "3", 0, "ab19e696-e057-467a-8e55-bae13659e0ba", "Staff@fpt.com", true, false, null, null, "Staff@fpt.com", "AQAAAAEAACcQAAAAEBeprfmutEvsVc9Ih0HnWu6/IwXI8Halk4lEWpnTdaEn/3OHNvalFaWq9I6ExNsl0w==", null, false, "3a8fb7b9-77e1-46d0-a808-7608a3bd5b64", false, "Staff@fpt.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "A", "1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "B", "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "A", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "B", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
