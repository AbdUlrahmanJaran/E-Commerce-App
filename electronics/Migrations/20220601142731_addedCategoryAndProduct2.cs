using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Electronics.Migrations
{
    public partial class addedCategoryAndProduct2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AboutProduct", "CategoryId", "MakerName", "Price", "ReleaseDate", "SubName" },
                values: new object[,]
                {
                    { 1, "1tb SSD storage, 2x8 ddr4 ram 3000mhz, i5-10th, nvidia mx230", 1, "Asus", 799.89999999999998, new DateTime(2022, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "XO2022" },
                    { 2, "500gb SSD storage, 8 ddr4 ram 3666mhz", 1, "Apple", 999.89999999999998, new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mac 2019" },
                    { 3, "128gb storage", 2, "Apple", 650.0, new DateTime(2019, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iphone 11" },
                    { 4, "128gb storage, 6gb ram", 2, "Poco", 199.90000000000001, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "X3 NFC" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
