using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class m333 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14f0db67-6315-4e95-8802-7164081fdaee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b61d8af-2668-4e0a-903f-43411c514139");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a7228b92-cf90-41b2-99ad-e21781640740", "65020485-277a-42d6-8b46-b2fc10e45ea3", "User", "user" },
                    { "e2ae46dd-236f-43d1-835a-ea89b8c2cf2e", "694db56d-1c28-443d-9e96-c276956af641", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "14f0db67-6315-4e95-8802-7164081fdaee", "9ac25df8-21e6-4ad7-a901-dc31a4e80449", "User", "user" },
                    { "2b61d8af-2668-4e0a-903f-43411c514139", "eba817b3-d4e3-4156-84b1-a1f61e8bace2", "Admin", "admin" }
                });
        }
    }
}
