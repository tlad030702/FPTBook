using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTBook.Migrations
{
    public partial class FPTBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A",
                column: "ConcurrencyStamp",
                value: "a7f1d279-15ff-4466-b4b3-bb4806387bec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B",
                column: "ConcurrencyStamp",
                value: "6951be11-d519-4594-adf1-aae2032bc7e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C",
                column: "ConcurrencyStamp",
                value: "d57d6eaa-9dbe-4c73-a05f-be9b37fad93e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Address", "ConcurrencyStamp", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "Ha noi", "2ac31ab6-bc30-4ede-b1ae-bd91a97dd982", "Duy Duong", "AQAAAAEAACcQAAAAENKrTOY3gaqulhBfyiZCIoktPO4AgmRhVtUeeNQJX07/DlU0beelvkMAMHrmetY0yw==", "624b6f0f-4c2b-46ac-a695-40628e484b65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "Address", "ConcurrencyStamp", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "Ha noi", "5e831c85-49ab-4d57-bc97-cd187a9472da", "Minh Duc", "AQAAAAEAACcQAAAAEEFvyT2mOMPs+EfB+1FCdrgx5leY/dF+7CQHo0dpRYYBviYmddoJeRf3e6JOHVyJEg==", "9ed09ebb-025c-4dfa-a320-6458fda06b39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "Address", "ConcurrencyStamp", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "Ha noi", "135a98bc-e812-48ea-a79b-62b8cb424c3f", "Toan Duc", "AQAAAAEAACcQAAAAEKZFnDj6idB3SQCe/WfxXIBJVyAa1D937g/v+TrWx0qw1+GB19fGmmZjbXtEtt/P8A==", "27b02cb3-4285-4074-8570-0b6332bdd212" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A",
                column: "ConcurrencyStamp",
                value: "7d205837-b0a9-40b8-bd0e-677f9aa0fbdb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B",
                column: "ConcurrencyStamp",
                value: "3258990b-c777-4d3f-be4c-ccd25c110060");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C",
                column: "ConcurrencyStamp",
                value: "81976675-d3d5-4dc8-9664-72ed3639adb1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91b10d0b-275b-46e4-8614-6fe426386f49", "AQAAAAEAACcQAAAAEMoRN8Vi/2ETWiKuUgj8Waf4U5IQ1ZgtMZDU7EgO7MQ/vCmiHOpF+r8NfZrbjTbXAw==", "741be129-9da2-44a6-acdb-6195f7ff240b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c795034c-0528-4851-81d0-46bf15b39964", "AQAAAAEAACcQAAAAEDCK7PJHOgd8BuSXJNEKeUEcFJonBzixpR2Q60DDG8Ccyqb+4XM/G5PRhJIXFZxcZQ==", "eb5b99d2-8088-432b-945a-573e54c8f36a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab19e696-e057-467a-8e55-bae13659e0ba", "AQAAAAEAACcQAAAAEBeprfmutEvsVc9Ih0HnWu6/IwXI8Halk4lEWpnTdaEn/3OHNvalFaWq9I6ExNsl0w==", "3a8fb7b9-77e1-46d0-a808-7608a3bd5b64" });
        }
    }
}
