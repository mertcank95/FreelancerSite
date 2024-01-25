using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ce26fa8-9048-475f-ac23-c8b6dc6ff748");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b418913a-fb0f-4843-a111-655f130e9602");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4d1d8f1-0925-4551-b564-0edb9242f74d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e30ac1f0-fb73-4f82-82cb-9864730ffbec");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyDescription",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "CompanyId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

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

            migrationBuilder.DropColumn(
                name: "CompanyDescription",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "CompanyId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ce26fa8-9048-475f-ac23-c8b6dc6ff748", "5e12add1-8842-4a14-b42b-d0e3a7170695", "User", "USER" },
                    { "b418913a-fb0f-4843-a111-655f130e9602", "3d96bb86-dc68-4586-83c9-b40cbcf66ee1", "None", "NONE" },
                    { "b4d1d8f1-0925-4551-b564-0edb9242f74d", "75e5ed53-81e1-46df-8a06-7b1dc51d10ff", "Admin", "ADMİN" },
                    { "e30ac1f0-fb73-4f82-82cb-9864730ffbec", "51fdc14f-541d-4837-86a5-eb93e20b082f", "Company", "COMPANY" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId");
        }
    }
}
