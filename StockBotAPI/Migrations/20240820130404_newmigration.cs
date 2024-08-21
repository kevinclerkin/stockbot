using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockBotAPI.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0adbfbfe-3e77-4825-9dc7-47f2cc874987");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bafd79a8-b5f2-4839-9d75-28a0c9423024");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "684c99f7-8634-4563-b7fb-749421608c20", null, "Admin", "ADMIN" },
                    { "d39299da-ec3f-4666-b13a-aabc7fbe60d1", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "684c99f7-8634-4563-b7fb-749421608c20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d39299da-ec3f-4666-b13a-aabc7fbe60d1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0adbfbfe-3e77-4825-9dc7-47f2cc874987", null, "Admin", "ADMIN" },
                    { "bafd79a8-b5f2-4839-9d75-28a0c9423024", null, "User", "USER" }
                });
        }
    }
}
