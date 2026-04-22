using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMedia.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductPointAndCreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedDate",
                table: "ProductComments",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "ProductComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2426));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2433));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 21, 20, 50, 1, 498, DateTimeKind.Local).AddTicks(2441));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProductComments");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "ProductComments");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9441));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9443));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 16, 19, 26, 58, 321, DateTimeKind.Local).AddTicks(9453));
        }
    }
}
