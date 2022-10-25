using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodMasters2.Core.Migrations
{
    public partial class CorrectingRelations3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterMasterPiece");

            migrationBuilder.AddColumn<string>(
                name: "MasterId",
                table: "MasterPieces",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPieces_MasterId",
                table: "MasterPieces",
                column: "MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterPieces_AspNetUsers_MasterId",
                table: "MasterPieces",
                column: "MasterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterPieces_AspNetUsers_MasterId",
                table: "MasterPieces");

            migrationBuilder.DropIndex(
                name: "IX_MasterPieces_MasterId",
                table: "MasterPieces");

            migrationBuilder.DropColumn(
                name: "MasterId",
                table: "MasterPieces");

            migrationBuilder.CreateTable(
                name: "MasterMasterPiece",
                columns: table => new
                {
                    MasterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MasterPieceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterMasterPiece", x => new { x.MasterId, x.MasterPieceId });
                    table.ForeignKey(
                        name: "FK_MasterMasterPiece_AspNetUsers_MasterId",
                        column: x => x.MasterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterMasterPiece_MasterPieces_MasterPieceId",
                        column: x => x.MasterPieceId,
                        principalTable: "MasterPieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterMasterPiece_MasterPieceId",
                table: "MasterMasterPiece",
                column: "MasterPieceId");
        }
    }
}
