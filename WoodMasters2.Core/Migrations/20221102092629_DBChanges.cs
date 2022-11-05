using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodMasters2.Core.Migrations
{
    public partial class DBChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterPieceCategory");

            migrationBuilder.DropTable(
                name: "WoodStain");

            migrationBuilder.DropTable(
                name: "WoodSupplier");

            migrationBuilder.AddColumn<int>(
                name: "StainId",
                table: "Woods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Woods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "MasterPieces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Woods_StainId",
                table: "Woods",
                column: "StainId");

            migrationBuilder.CreateIndex(
                name: "IX_Woods_SupplierId",
                table: "Woods",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPieces_CategoryId",
                table: "MasterPieces",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterPieces_Categories_CategoryId",
                table: "MasterPieces",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Woods_Stains_StainId",
                table: "Woods",
                column: "StainId",
                principalTable: "Stains",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Woods_Suppliers_SupplierId",
                table: "Woods",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterPieces_Categories_CategoryId",
                table: "MasterPieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Woods_Stains_StainId",
                table: "Woods");

            migrationBuilder.DropForeignKey(
                name: "FK_Woods_Suppliers_SupplierId",
                table: "Woods");

            migrationBuilder.DropIndex(
                name: "IX_Woods_StainId",
                table: "Woods");

            migrationBuilder.DropIndex(
                name: "IX_Woods_SupplierId",
                table: "Woods");

            migrationBuilder.DropIndex(
                name: "IX_MasterPieces_CategoryId",
                table: "MasterPieces");

            migrationBuilder.DropColumn(
                name: "StainId",
                table: "Woods");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Woods");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MasterPieces");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "MasterPieceCategory",
                columns: table => new
                {
                    MasterPieceId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPieceCategory", x => new { x.MasterPieceId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_MasterPieceCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterPieceCategory_MasterPieces_MasterPieceId",
                        column: x => x.MasterPieceId,
                        principalTable: "MasterPieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WoodStain",
                columns: table => new
                {
                    WoodId = table.Column<int>(type: "int", nullable: false),
                    StainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WoodStain", x => new { x.WoodId, x.StainId });
                    table.ForeignKey(
                        name: "FK_WoodStain_Stains_StainId",
                        column: x => x.StainId,
                        principalTable: "Stains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WoodStain_Woods_WoodId",
                        column: x => x.WoodId,
                        principalTable: "Woods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WoodSupplier",
                columns: table => new
                {
                    WoodId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WoodSupplier", x => new { x.WoodId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_WoodSupplier_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WoodSupplier_Woods_WoodId",
                        column: x => x.WoodId,
                        principalTable: "Woods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterPieceCategory_CategoryId",
                table: "MasterPieceCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WoodStain_StainId",
                table: "WoodStain",
                column: "StainId");

            migrationBuilder.CreateIndex(
                name: "IX_WoodSupplier_SupplierId",
                table: "WoodSupplier",
                column: "SupplierId");
        }
    }
}
