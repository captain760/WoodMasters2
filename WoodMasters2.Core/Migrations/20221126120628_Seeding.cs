using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodMasters2.Core.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    MasterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorite_AspNetUsers_MasterId",
                        column: x => x.MasterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MasterPieces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Depth = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    MasterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterPieces_AspNetUsers_MasterId",
                        column: x => x.MasterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterPieces_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Woods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StainId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Woods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Woods_Stains_StainId",
                        column: x => x.StainId,
                        principalTable: "Stains",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Woods_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    PostingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MasterPieceId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_Author",
                        column: x => x.Author,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_MasterPieces_MasterPieceId",
                        column: x => x.MasterPieceId,
                        principalTable: "MasterPieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MasterAddress",
                columns: table => new
                {
                    MasterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAddress", x => new { x.MasterId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_MasterAddress_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterAddress_AspNetUsers_MasterId",
                        column: x => x.MasterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterPieceWood",
                columns: table => new
                {
                    MasterPieceId = table.Column<int>(type: "int", nullable: false),
                    WoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPieceWood", x => new { x.MasterPieceId, x.WoodId });
                    table.ForeignKey(
                        name: "FK_MasterPieceWood_MasterPieces_MasterPieceId",
                        column: x => x.MasterPieceId,
                        principalTable: "MasterPieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterPieceWood_Woods_WoodId",
                        column: x => x.WoodId,
                        principalTable: "Woods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "Experience", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "714a3393-02ae-424a-afa7-2c13474cbe71", new DateTime(2022, 11, 26, 14, 6, 27, 776, DateTimeKind.Local).AddTicks(230), "b_eftimov@yahoo.com", false, 0, "Boris", "Eftimov", false, null, "B_EFTIMOV@YAHOO.COM", "CAPTAIN76", "AQAAAAEAACcQAAAAENcAi+ftFHfpf7rU6cvpRv+dqHs8cd+ldkVL3tHT00Cmh/vS7B5Mpg8ZnJF9NkRpsQ==", null, false, "38fcf561-10b6-4a69-a3b6-876811fbe5d3", false, "captain76" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "ce759c03-d077-41c0-8512-5288136f7811", new DateTime(2022, 11, 26, 14, 6, 27, 768, DateTimeKind.Local).AddTicks(4971), "m_eftimov@yahoo.com", false, 0, "Momchil", "Eftimov", false, null, "M_EFTIMOV@YAHOO.COM", "MOMO12", "AQAAAAEAACcQAAAAEAOMz+WrV7Vg80qb9fV7FYmtJwQZupC+DpdGoKfTbr29M9FgXdk7n4GxjlPdKtY1yg==", null, false, "12553aa0-c6d6-4c98-8362-2b1ff68a2cff", false, "Momo12" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Woodcarving" },
                    { 2, "Woodturning" },
                    { 3, "Pyrography" },
                    { 4, "Intarsia" },
                    { 5, "Scrow Sawing" },
                    { 6, "Cabinetry and Furniture" },
                    { 7, "Carpentry and Joinery" },
                    { 8, "Construction" },
                    { 9, "Miscelaneous" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bulgaria" },
                    { 2, "Romania" },
                    { 3, "Greece" },
                    { 4, "Serbia" },
                    { 5, "Turkey" },
                    { 6, "Brazil" },
                    { 7, "Russia" },
                    { 8, "Ukraine" },
                    { 9, "USA" },
                    { 10, "Canada" }
                });

            migrationBuilder.InsertData(
                table: "Stains",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Clear Coat" },
                    { 2, "Exotic Redwood" },
                    { 3, "Vintage Modern" },
                    { 4, "Golden Sunset" },
                    { 5, "Mocha" },
                    { 6, "Maroccan Red" },
                    { 7, "Silk Grey" },
                    { 8, "Whitish" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bari Trans LTD" },
                    { 2, "Ilza LTD" },
                    { 3, "KoronaIm LTD" },
                    { 4, "Hardi LTD" },
                    { 5, "JAF Bulgaria" },
                    { 6, "Centaur LTD" }
                });

            migrationBuilder.InsertData(
                table: "Woods",
                columns: new[] { "Id", "StainId", "SupplierId", "Type" },
                values: new object[,]
                {
                    { 1, null, null, "Oak" },
                    { 2, null, null, "Walnut" },
                    { 3, null, null, "Pine" },
                    { 4, null, null, "Beech" },
                    { 5, null, null, "Linden" },
                    { 6, null, null, "Poplar" },
                    { 7, null, null, "Birch" }
                });

            migrationBuilder.InsertData(
                table: "Woods",
                columns: new[] { "Id", "StainId", "SupplierId", "Type" },
                values: new object[] { 8, null, null, "Cedar" });

            migrationBuilder.InsertData(
                table: "Woods",
                columns: new[] { "Id", "StainId", "SupplierId", "Type" },
                values: new object[] { 9, null, null, "Ash" });

            migrationBuilder.InsertData(
                table: "Woods",
                columns: new[] { "Id", "StainId", "SupplierId", "Type" },
                values: new object[] { 10, null, null, "Acer" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CountryId", "PlaceName" },
                values: new object[,]
                {
                    { 1, 1, "Varna, 37 Evlogi Georgiev str." },
                    { 2, 1, "Sofia, 3 Musala str." },
                    { 3, 5, "Odrin, 7 Sultan Mehmed str." }
                });

            migrationBuilder.InsertData(
                table: "MasterPieces",
                columns: new[] { "Id", "CategoryId", "Depth", "Description", "ImageURL", "IsDeleted", "Length", "MasterId", "Name", "Price", "Quantity", "Rating", "Width" },
                values: new object[,]
                {
                    { 1, 1, 10.0, "A master-piece from an unknown master found on a garrage sale", "https://www.harvardmagazine.com/sites/default/files/styles/4x3_main/public/img/article/0613/ja13_page_31_02.jpg", false, 40.0, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "Flowers", 2000m, 1, 10m, 60.0 },
                    { 2, 4, 5.0, "A beautiful tribal mosaics build from stained woods", "https://i0.wp.com/100things2do.ca/wp-content/uploads/2021/06/scrapwood-snowflake-12.jpg", false, 50.0, "dea12856-c198-4129-b3f3-b893d8395082", "Tribal Mosaic", 100m, 2, 5m, 50.0 },
                    { 3, 2, 12.0, "A wooden bowl from cherry tree", "https://www.dougsturnings.com/wp-content/uploads/2020/04/Doug-Heck-Maryland-Woodturner-8636-1024x682-1.jpg", false, 20.0, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "Wooden Bowl", 50m, 4, 8m, 20.0 },
                    { 4, 7, 40.0, "A wooden crate to store your staff all around!!!", "https://www.ana-white.com/sites/default/files/wood-crate-how-to-build-1.jpg", false, 60.0, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "Crate", 20m, 100, 9m, 40.0 }
                });

            migrationBuilder.InsertData(
                table: "MasterAddress",
                columns: new[] { "AddressId", "MasterId" },
                values: new object[] { 2, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "MasterAddress",
                columns: new[] { "AddressId", "MasterId" },
                values: new object[] { 1, "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Author",
                table: "Comments",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MasterPieceId",
                table: "Comments",
                column: "MasterPieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_MasterId",
                table: "Favorite",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterAddress_AddressId",
                table: "MasterAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPieces_CategoryId",
                table: "MasterPieces",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPieces_MasterId",
                table: "MasterPieces",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPieceWood_WoodId",
                table: "MasterPieceWood",
                column: "WoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Woods_StainId",
                table: "Woods",
                column: "StainId");

            migrationBuilder.CreateIndex(
                name: "IX_Woods_SupplierId",
                table: "Woods",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "MasterAddress");

            migrationBuilder.DropTable(
                name: "MasterPieceWood");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "MasterPieces");

            migrationBuilder.DropTable(
                name: "Woods");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Stains");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
