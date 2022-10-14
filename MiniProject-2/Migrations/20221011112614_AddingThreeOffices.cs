using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProject_2.Migrations
{
    public partial class AddingThreeOffices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "ConvertPriceFromUSD", "Country", "Currency" },
                values: new object[] { 1, 0.84999999999999998, "England", "GBP" });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "ConvertPriceFromUSD", "Country", "Currency" },
                values: new object[] { 2, 10.42, "Sweden", "SEK" });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "ConvertPriceFromUSD", "Country", "Currency" },
                values: new object[] { 3, 1.0, "USA", "USD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
