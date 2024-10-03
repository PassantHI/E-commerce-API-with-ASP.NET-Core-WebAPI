using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c9ebfef-f4c9-4c5f-9218-0fa219aa8906");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac87eff-3b83-4e0e-817a-728178151402");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14f0db67-6315-4e95-8802-7164081fdaee", "9ac25df8-21e6-4ad7-a901-dc31a4e80449", "User", "user" },
                    { "2b61d8af-2668-4e0a-903f-43411c514139", "eba817b3-d4e3-4156-84b1-a1f61e8bace2", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14f0db67-6315-4e95-8802-7164081fdaee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b61d8af-2668-4e0a-903f-43411c514139");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c9ebfef-f4c9-4c5f-9218-0fa219aa8906", "127b1caa-f87b-4ad4-b99f-6d9883cd9c2a", "Admin", "admin" },
                    { "cac87eff-3b83-4e0e-817a-728178151402", "5d7e1c37-842c-48bf-9868-a74aad59caed", "User", "user" }
                });
        }
    }
}
