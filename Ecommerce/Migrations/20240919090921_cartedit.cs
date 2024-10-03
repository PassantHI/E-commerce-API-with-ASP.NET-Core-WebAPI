using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class cartedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10572c0d-0ddd-44f6-bdff-8723dfdc5bbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3a2952e-a3d5-417f-a034-858042842d2d");

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "55801a18-d1d0-467a-934c-1dae1eec8a3a", "770e7e67-18a3-4d73-a274-f26c1bacb69a", "Admin", "admin" },
                    { "a66557a5-2a28-41b1-a785-04c84f2c0829", "4d3d6e61-0637-4fe9-9a05-738b9329cbd8", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55801a18-d1d0-467a-934c-1dae1eec8a3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a66557a5-2a28-41b1-a785-04c84f2c0829");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Product");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10572c0d-0ddd-44f6-bdff-8723dfdc5bbb", "0cad4f38-de3f-4776-90be-2805cbcfa9f5", "Admin", "admin" },
                    { "f3a2952e-a3d5-417f-a034-858042842d2d", "14b29fab-5c62-4347-988a-78fd3b64c21b", "User", "user" }
                });
        }
    }
}
