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
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    MasterPieceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_MasterPieces_MasterPieceId",
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
                values: new object[] { "b7bfbc72-fac8-4a94-a713-d3a9148f8f1d", new DateTime(2022, 12, 10, 10, 23, 31, 54, DateTimeKind.Local).AddTicks(6609), "AQAAAAEAACcQAAAAEC9WVmO2uw84Wnmn6j2qz2pzTEdetLY9GtTimU/uie0H90C7M9eEZ+pBN4dro6yV3w==", "fce8aed7-5018-47e7-9abb-7a8e2577dd64" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a777aae-0d31-48cf-9612-095e419c8769", new DateTime(2022, 12, 10, 10, 23, 31, 47, DateTimeKind.Local).AddTicks(615), "AQAAAAEAACcQAAAAEM9kiqBSkfdixbKFcy0OMDvURLmoDtRjKFwFPJjZHcNmpahDaDes8mnxPVIxM6/ZAQ==", "92bb6fe5-837a-4d8e-a8a7-8caae7469042" });

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
                columns: new[] { "Id", "MasterPieceId", "Rate" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 2, 4 },
                    { 3, 3, 5 },
                    { 4, 4, 3 },
                    { 5, 1, 5 },
                    { 6, 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MasterPieceId",
                table: "Ratings",
                column: "MasterPieceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

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
                columns: new[] { "Description", "Rating" },
                values: new object[] { "A master-piece from an unknown master found on a garrage sale", 10m });

            migrationBuilder.UpdateData(
                table: "MasterPieces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "Rating" },
                values: new object[] { 100m, 5m });

            migrationBuilder.UpdateData(
                table: "MasterPieces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "Rating" },
                values: new object[] { 50m, 8m });

            migrationBuilder.UpdateData(
                table: "MasterPieces",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 9m);
        }
    }
}
