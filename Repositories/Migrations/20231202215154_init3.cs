using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f3ccc51-ddc6-4366-9289-9d36b11338e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b253c68-f219-4dd5-8598-ccf966784fff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce6951c6-5cca-45f4-9a99-76bda7fe632d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d14f0531-dc82-4918-a87e-23f71f8cd36f");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b127ba9-bc59-43b9-bf52-895aae6ddd91", "c38afdac-549c-4a98-8c12-6609aa0ebe0f", "User", "USER" },
                    { "9db81222-676a-4b2a-997f-27c9c13e18cd", "c09eb5fa-2b28-425b-a2df-52f59af8ed9a", "None", "NONE" },
                    { "a57f2de2-a1bc-439f-984d-4d9943e8acd5", "b097f7b0-6acc-45b9-91c4-e0fe762f838b", "Admin", "ADMİN" },
                    { "a7dbf402-0812-4220-ac93-3c698e7e470c", "05a607f1-8a12-4b30-89a0-7bdbaf096c68", "Company", "COMPANY" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b127ba9-bc59-43b9-bf52-895aae6ddd91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9db81222-676a-4b2a-997f-27c9c13e18cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a57f2de2-a1bc-439f-984d-4d9943e8acd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7dbf402-0812-4220-ac93-3c698e7e470c");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f3ccc51-ddc6-4366-9289-9d36b11338e9", "d8a51612-34be-4f7c-86de-c0639e81e25f", "Company", "COMPANY" },
                    { "6b253c68-f219-4dd5-8598-ccf966784fff", "ccbeb2ab-4a58-4d85-b8a4-f14a068ee383", "None", "NONE" },
                    { "ce6951c6-5cca-45f4-9a99-76bda7fe632d", "0b5f772f-1e4f-4958-b14e-fcfed5fb53db", "Admin", "ADMİN" },
                    { "d14f0531-dc82-4918-a87e-23f71f8cd36f", "5b2fc1c0-7874-4027-9b7c-b9f15417712d", "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
