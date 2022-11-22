using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodMasters2.Core.Migrations
{
    public partial class AddRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    PostingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MasterPieceId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_MasterPieces_MasterPieceId",
                        column: x => x.MasterPieceId,
                        principalTable: "MasterPieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MasterPieceId",
                table: "Comments",
                column: "MasterPieceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
