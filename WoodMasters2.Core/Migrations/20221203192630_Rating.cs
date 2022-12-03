using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodMasters2.Core.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "MasterPieces");

            migrationBuilder.CreateTable(
                name: "StarRating",
                columns: table => new
                {
                    RateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterPieceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarRating", x => x.RateId);
                    table.ForeignKey(
                        name: "FK_StarRating_MasterPieces_MasterPieceId",
                        column: x => x.MasterPieceId,
                        principalTable: "MasterPieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_StarRating_MasterPieceId",
                table: "StarRating",
                column: "MasterPieceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StarRating");

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "MasterPieces",
                type: "decimal(4,2)",
                precision: 4,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba8fb183-7209-4d5e-ac61-a58b472bf6f5", new DateTime(2022, 12, 3, 18, 10, 3, 270, DateTimeKind.Local).AddTicks(6961), "AQAAAAEAACcQAAAAEDFuiUj98aBwNHqbiLuNaG8KFPCYr/m2wFTslUJsv8wh3mM2KcE333E/YtgqXR2RFQ==", "5adaef4f-4797-49a9-a5a1-bf5fcf890b8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "574b8ec4-2d4f-4ff8-a56d-fc33e15b9bf5", new DateTime(2022, 12, 3, 18, 10, 3, 262, DateTimeKind.Local).AddTicks(8570), "AQAAAAEAACcQAAAAEM4GNEUW+VKSKEDywJvkwfm+RM1ar6SZy2/LPBOlf+PgyxQpUJLNilMrPgc0Ng4prw==", "eb69ec43-5fe1-453c-9d45-50ffad1205af" });

            migrationBuilder.UpdateData(
                table: "MasterPieces",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "MasterPieces",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "MasterPieces",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 8m);

            migrationBuilder.UpdateData(
                table: "MasterPieces",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 9m);
        }
    }
}
