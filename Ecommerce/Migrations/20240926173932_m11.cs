using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class m11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7228b92-cf90-41b2-99ad-e21781640740");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2ae46dd-236f-43d1-835a-ea89b8c2cf2e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d8153591-efca-40d6-b83f-f28b03e5b4be", "cab8ee54-ce44-4e2c-8669-811f905e9c79", "User", "user" },
                    { "ed403dab-f767-4deb-bc79-bf06e774bfb7", "1f87b4ef-b065-42ec-b426-5d96104348cb", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8153591-efca-40d6-b83f-f28b03e5b4be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed403dab-f767-4deb-bc79-bf06e774bfb7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a7228b92-cf90-41b2-99ad-e21781640740", "65020485-277a-42d6-8b46-b2fc10e45ea3", "User", "user" },
                    { "e2ae46dd-236f-43d1-835a-ea89b8c2cf2e", "694db56d-1c28-443d-9e96-c276956af641", "Admin", "admin" }
                });
        }
    }
}
