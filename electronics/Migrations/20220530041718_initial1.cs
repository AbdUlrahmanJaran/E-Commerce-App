using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace electronics.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MakerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Info", "Name" },
                values: new object[] { 1, "Browse a wide selection of laptops from different Makers", "Laptops" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Info", "Name" },
                values: new object[] { 2, "Browse a wide selection of Phones from different Makers", "Mobile Phones" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
