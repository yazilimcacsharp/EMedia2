using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMedia.Migrations
{
    /// <inheritdoc />
    public partial class DiscountRateAddedForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountRate",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(4922), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(4935), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(4937), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(4939), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(5026), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(5032), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(5034), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(5035), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(5037), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(5039), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(5041), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(5043), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(5044), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(5046), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(5048), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(5050), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "DiscountRate" },
                values: new object[] { new DateTime(2026, 3, 24, 19, 47, 53, 525, DateTimeKind.Local).AddTicks(5051), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountRate",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4640));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4647));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 17, 20, 9, 29, 266, DateTimeKind.Local).AddTicks(4658));
        }
    }
}
