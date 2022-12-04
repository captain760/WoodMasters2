using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodMasters2.Core.Migrations
{
    public partial class AddRatingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StarRating_MasterPieces_MasterPieceId",
                table: "StarRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StarRating",
                table: "StarRating");

            migrationBuilder.RenameTable(
                name: "StarRating",
                newName: "Ratings");

            migrationBuilder.RenameIndex(
                name: "IX_StarRating_MasterPieceId",
                table: "Ratings",
                newName: "IX_Ratings_MasterPieceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "RateId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_MasterPieces_MasterPieceId",
                table: "Ratings",
                column: "MasterPieceId",
                principalTable: "MasterPieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_MasterPieces_MasterPieceId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "StarRating");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_MasterPieceId",
                table: "StarRating",
                newName: "IX_StarRating_MasterPieceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarRating",
                table: "StarRating",
                column: "RateId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ac61050-d989-4a22-8ad9-2bce36c2d31b", new DateTime(2022, 12, 3, 21, 26, 29, 848, DateTimeKind.Local).AddTicks(4453), "AQAAAAEAACcQAAAAEL6ot97TWscU92lAtu+a/6p9Xdbg4PkFonOoXJKVhv+ztIvPR3VrswAFnbBZmCEs6g==", "3f4d4fe9-0ef3-4282-9f4c-961c619274bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45db605b-17d2-4959-a03f-9d12cc087441", new DateTime(2022, 12, 3, 21, 26, 29, 840, DateTimeKind.Local).AddTicks(8769), "AQAAAAEAACcQAAAAEHk+RUxisga/VN9SsebplmYvZBwpzd7fVhKliq7wm+xwRwFmhqtJ4e2GjfcB8H/aig==", "db90f384-d501-4c45-a4ef-ede2085fa169" });

            migrationBuilder.AddForeignKey(
                name: "FK_StarRating_MasterPieces_MasterPieceId",
                table: "StarRating",
                column: "MasterPieceId",
                principalTable: "MasterPieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
