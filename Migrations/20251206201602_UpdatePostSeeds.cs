using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pawbook2._0.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePostSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Breed", "Gender", "Username" },
                values: new object[,]
                {
                    { 2, 3, "Labrador", "Female", "LunaTheLab" },
                    { 3, 2, "Goldendoodle", "Male", "SamsonTheDood" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Caption", "CreatedAt", "ImageUrl", "Likes", "UserId" },
                values: new object[,]
                {
                    { 2, "Found my favourite stick 🪵", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/Luna-the-lab/Luna-the-lab.jpg", 22, 2 },
                    { 3, "Snuggles time.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/Samson-thedood/Samson-thedood-1.jpg", 14, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 20, 9, 9, 100, DateTimeKind.Utc).AddTicks(6080));
        }
    }
}
