using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Murat.API.Migrations
{
    public partial class addCategoryIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 9, 43, 47, 592, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 9, 43, 47, 594, DateTimeKind.Local).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 9, 43, 47, 594, DateTimeKind.Local).AddTicks(1394));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 15, 45, 39, 21, DateTimeKind.Local).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 15, 45, 39, 22, DateTimeKind.Local).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 15, 45, 39, 22, DateTimeKind.Local).AddTicks(6362));
        }
    }
}
