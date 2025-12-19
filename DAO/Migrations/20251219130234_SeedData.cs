using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAO.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Bolesławiec" },
                    { 2, 4, "Royal Copenhagen" }
                });

            migrationBuilder.InsertData(
                table: "CeramicItems",
                columns: new[] { "Id", "CeramicType", "FiringType", "Name", "ProducerId" },
                values: new object[,]
                {
                    { 1, 1, 2, "Mug", 1 },
                    { 2, 0, 1, "Plate", 1 },
                    { 3, 3, 0, "Vase", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CeramicItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CeramicItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CeramicItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
