using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class roLes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10572c0d-0ddd-44f6-bdff-8723dfdc5bbb", "0cad4f38-de3f-4776-90be-2805cbcfa9f5", "Admin", "admin" },
                    { "f3a2952e-a3d5-417f-a034-858042842d2d", "14b29fab-5c62-4347-988a-78fd3b64c21b", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10572c0d-0ddd-44f6-bdff-8723dfdc5bbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3a2952e-a3d5-417f-a034-858042842d2d");
        }
    }
}
