using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodMasters2.Core.Migrations
{
    public partial class RatingFieldAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8a553eb-9f18-4887-961b-566ff7687651", new DateTime(2022, 12, 8, 3, 46, 3, 655, DateTimeKind.Local).AddTicks(5218), "AQAAAAEAACcQAAAAEFpDbi7oLGcRh/F2K+sOPWPx9xvvIxA2sxr5Pp2K5OTGNl/re+7/3fGzk3PnKe6QXQ==", "18908500-f6bc-49de-bdb9-b604104aad86" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcca26bd-e8b1-4cfe-9e31-55a53dee1496", new DateTime(2022, 12, 8, 3, 46, 3, 648, DateTimeKind.Local).AddTicks(5208), "AQAAAAEAACcQAAAAEJQVHQE9OasgUJ8GudgyQGeUNq1QQd2fmlUL6z8gHab3Ubx2ODOAYfgDyR0/fSw+JQ==", "93f39de2-b429-4483-80a9-3a674e9e22e9" });

            migrationBuilder.UpdateData(
                table: "MasterPieces",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Flowers and leaves carved as a 3D model");

            migrationBuilder.UpdateData(
                table: "MasterPieces",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "MasterPieces",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 100m);

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RateId", "MasterPieceId", "Rate" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 2, 4 },
                    { 3, 3, 5 },
                    { 4, 4, 3 },
                    { 5, 1, 5 },
                    { 6, 3, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "RateId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "RateId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "RateId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "RateId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "RateId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "RateId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5cfa6b6-99f2-4b59-b20a-41906dd604a0", new DateTime(2022, 12, 4, 0, 40, 42, 810, DateTimeKind.Local).AddTicks(5502), "AQAAAAEAACcQAAAAEMeX03IGRDWsMbKmuLSzlFx0P0pmpRixZs9lFFqu78bqZSPZmhXTC9oBYRtnNPHhTQ==", "b3de068b-a874-4094-8667-4da4e14d460c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92111590-c455-4ac6-8458-0bb89c10ecc8", new DateTime(2022, 12, 4, 0, 40, 42, 802, DateTimeKind.Local).AddTicks(8438), "AQAAAAEAACcQAAAAECS166G66+vmYV2WPDuI8L1StJfF8Sw9vCBUTzyX0+rwrMJEa02fYtoaJkFW8DcKEw==", "1b11bf52-ed00-4a80-82e7-7d9d130015ac" });

            migrationBuilder.UpdateData(
                table: "MasterPieces",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A master-piece from an unknown master found on a garrage sale");

            migrationBuilder.UpdateData(
                table: "MasterPieces",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "MasterPieces",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 50m);
        }
    }
}
