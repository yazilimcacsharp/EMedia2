using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EMedia.Migrations
{
    /// <inheritdoc />
    public partial class SubCategoriesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, 1, true, "Pop" },
                    { 2, 1, true, "Rock" },
                    { 3, 1, true, "Jazz" },
                    { 4, 1, true, "Blues" },
                    { 5, 1, true, "Klasik" },
                    { 6, 1, true, "Metal" },
                    { 7, 1, true, "Reggae" },
                    { 8, 2, true, "Aksiyon" },
                    { 9, 2, true, "Dram" },
                    { 10, 2, true, "Komedi" },
                    { 11, 3, true, "Trajedi" },
                    { 12, 3, true, "Komedi" },
                    { 13, 3, true, "Dram" },
                    { 14, 3, true, "Müzikli Tiyatro" },
                    { 15, 4, true, "Klasik Müzik Konserleri" },
                    { 16, 4, true, "Halk Müziği Konserleri" },
                    { 17, 4, true, "Akustik Konserler" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubCategories");
        }
    }
}
