using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class JobPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "JobPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Money = table.Column<float>(type: "real", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPosts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7f7b3459-0862-4f41-b712-5c2de3281f8c", "1429fe39-ae56-4270-8b05-244f3d835081", "User", "USER" },
                    { "896c94f8-4370-4da3-baac-c32c061bd091", "08701992-b0e2-433b-ba03-8821bdf11c16", "Company", "COMPANY" },
                    { "ad84e92f-dcce-4852-9c1b-4800cafe7cf5", "a9cfe898-1027-4452-b95d-b01bc3d1fc84", "None", "NONE" },
                    { "e90341e5-7d3b-4662-ac4b-dc11986a996f", "dff81e80-7e59-41a4-b349-5dd8449a4f7a", "Admin", "ADMİN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_CompanyId",
                table: "JobPosts",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPosts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f7b3459-0862-4f41-b712-5c2de3281f8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "896c94f8-4370-4da3-baac-c32c061bd091");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad84e92f-dcce-4852-9c1b-4800cafe7cf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e90341e5-7d3b-4662-ac4b-dc11986a996f");

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
        }
    }
}
