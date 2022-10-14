using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProject_2.Migrations
{
    public partial class AddingAssetsSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "Brand", "Model", "OfficeId", "PriceUSD", "PurchesDate", "Type" },
                values: new object[,]
                {
                    { 1, "Asus", "W324", 3, 2222.0, new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer" },
                    { 2, "Lenovo", "Yoga 730", 2, 1230.0, new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer" },
                    { 3, "Lenovo", "Yoga 430", 2, 1333.0, new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer" },
                    { 4, "HP", "EliteBook", 1, 2551.0, new DateTime(2022, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer" },
                    { 5, "HP", "EliteBook", 3, 2442.0, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer" },
                    { 6, "Acer", "One", 3, 675.0, new DateTime(2007, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer" },
                    { 7, "iPhone", "8", 1, 1111.0, new DateTime(2019, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone" },
                    { 8, "iPhone", "11", 1, 923.0, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone" },
                    { 9, "iPhone", "X", 3, 875.0, new DateTime(2020, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone" },
                    { 10, "Motorola", "Razr", 2, 533.0, new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone" },
                    { 11, "Sony", "Xperia", 2, 463.0, new DateTime(2011, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
