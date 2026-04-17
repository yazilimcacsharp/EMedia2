using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EMedia.Migrations
{
    /// <inheritdoc />
    public partial class Y : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    FotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "FotoPath", "IsActive", "Name", "Price", "Stock", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4611), "images/pop_album.jpg", true, "Pop Albümü - Greatest Hits", 49.90m, 100, 1 },
                    { 2, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4627), "images/rock_album.jpg", true, "Rock Albümü - Legends of Rock", 59.90m, 80, 2 },
                    { 3, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4629), "images/jazz_album.jpg", true, "Jazz Albümü - Smooth Jazz Collection", 39.90m, 60, 3 },
                    { 4, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4631), "images/blues_album.jpg", true, "Blues Albümü - Soulful Blues", 44.90m, 50, 4 },
                    { 5, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4636), "images/classical_album.jpg", true, "Klasik Albüm - Mozart Collection", 69.90m, 40, 5 },
                    { 6, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4638), "images/metal_album.jpg", true, "Metal Albümü - Heavy Metal Anthems", 54.90m, 70, 6 },
                    { 7, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4640), "images/reggae_album.jpg", true, "Reggae Albümü - Bob Marley Tribute", 42.90m, 90, 7 },
                    { 8, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4642), "images/action_madmax.jpg", true, "Aksiyon Filmi - Mad Max: Fury Road", 89.90m, 120, 8 },
                    { 9, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4643), "images/action_johnwick.jpg", true, "Aksiyon Filmi - John Wick", 79.90m, 100, 8 },
                    { 10, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4645), "images/drama_shawshank.jpg", true, "Dram Filmi - The Shawshank Redemption", 69.90m, 80, 9 },
                    { 11, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4647), "images/drama_forrestgump.jpg", true, "Dram Filmi - Forrest Gump", 74.90m, 90, 9 },
                    { 12, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4649), "images/comedy_mask.jpg", true, "Komedi Filmi - The Mask", 59.90m, 110, 10 },
                    { 13, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4650), "images/comedy_homealone.jpg", true, "Komedi Filmi - Home Alone", 64.90m, 130, 10 },
                    { 14, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4652), "images/tiyatro_trajedi_oidipus.jpg", true, "Trajedi Oyunu - Kral Oidipus", 99.90m, 50, 11 },
                    { 15, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4654), "images/tiyatro_komedi_yazgecesi.jpg", true, "Komedi Oyunu - Bir Yaz Gecesi Rüyası", 79.90m, 70, 12 },
                    { 16, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4656), "images/tiyatro_dram_hamlet.jpg", true, "Dram Oyunu - Hamlet", 89.90m, 60, 13 },
                    { 17, new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4658), "images/tiyatro_muzikli_lesmis.jpg", true, "Müzikli Tiyatro - Les Misérables", 119.90m, 40, 14 }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 18, 4, true, "Pop Konserleri" },
                    { 19, 4, true, "Rock Konserleri" },
                    { 20, 4, true, "Jazz Konserleri" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
