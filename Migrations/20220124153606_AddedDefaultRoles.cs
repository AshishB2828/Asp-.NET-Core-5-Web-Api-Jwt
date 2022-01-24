using Microsoft.EntityFrameworkCore.Migrations;

namespace ListingApi.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c928f918-7362-4b3e-8c95-b50b05973b67", "143a2187-1cdb-4ad0-81dc-c5f67696e2c8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2357cf0a-9a9c-4a4a-b5a7-a193b7e1564a", "0818fe2c-fd47-4998-8cb4-77d66f838e8f", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2357cf0a-9a9c-4a4a-b5a7-a193b7e1564a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c928f918-7362-4b3e-8c95-b50b05973b67");
        }
    }
}
