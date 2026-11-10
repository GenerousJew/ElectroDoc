using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectroDoc.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "permission",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "ManageMembers" },
                    { 2, "ManageCompanySettings" },
                    { 3, "CreateDocuments" },
                    { 4, "PrivateDrafts" },
                    { 5, "ViewPrivateDrafts" },
                    { 6, "ViewOthersDrafts" },
                    { 7, "EditOthersDrafts" },
                    { 8, "SendOthersDrafts" },
                    { 9, "ViewOthersDocuments" },
                    { 10, "SignDocuments" },
                    { 11, "CancelDocuments" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 11);
        }
    }
}
