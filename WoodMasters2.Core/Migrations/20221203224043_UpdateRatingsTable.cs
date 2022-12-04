using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodMasters2.Core.Migrations
{
    public partial class UpdateRatingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Ratings");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfd5e072-bbf1-492f-91ae-69d604f3ad12", new DateTime(2022, 12, 4, 0, 16, 18, 890, DateTimeKind.Local).AddTicks(5218), "AQAAAAEAACcQAAAAEFxHKlbv1xeAl65hBQ/SzCXt5rvJGiTz8/lq6J5koTOobv9gSMPvrbyW9NVrSYgBGg==", "d51f0a75-7b04-4936-bcb9-948ab4ae87c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8023e3b6-0dc5-4104-942e-ad62ed977e1b", new DateTime(2022, 12, 4, 0, 16, 18, 883, DateTimeKind.Local).AddTicks(4977), "AQAAAAEAACcQAAAAEF8tpyP3rACH3xLKVFvHo4rHJlkk0r+ZM7ReAZNVrH/iu27UMIWuEMhDXX+54lSFHQ==", "89b29c8a-8dd7-4863-9dd3-2d51c647c212" });
        }
    }
}
