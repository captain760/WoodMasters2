using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodMasters2.Core.Migrations
{
    public partial class CommentUpdateWithMasterId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_Author",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Comments",
                newName: "MasterId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_Author",
                table: "Comments",
                newName: "IX_Comments_MasterId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d759a87a-1dc5-470c-b5f3-b9ae03cb4ef5", new DateTime(2022, 11, 30, 13, 9, 50, 484, DateTimeKind.Local).AddTicks(2843), "AQAAAAEAACcQAAAAEEfn7m6fpG2lAFo7oa1L3ZWW6aaTx+O8n3rWYpUytaziyoblRMan0V53TbGwXITSJA==", "28079895-43e7-4f07-84c9-6277790a2c5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a42b0e2f-ce9b-4c7b-baee-3dd6653d0b38", new DateTime(2022, 11, 30, 13, 9, 50, 476, DateTimeKind.Local).AddTicks(7680), "AQAAAAEAACcQAAAAEMxaB+7EF2c9VtYnT1N05iuuxT2mmgB3IPTZxR5pWP7OggiucxLgRMsPjimuYgjLzQ==", "1ed10c55-fc44-43ce-a122-3b50fc463f14" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_MasterId",
                table: "Comments",
                column: "MasterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_MasterId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "MasterId",
                table: "Comments",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MasterId",
                table: "Comments",
                newName: "IX_Comments_Author");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "714a3393-02ae-424a-afa7-2c13474cbe71", new DateTime(2022, 11, 26, 14, 6, 27, 776, DateTimeKind.Local).AddTicks(230), "AQAAAAEAACcQAAAAENcAi+ftFHfpf7rU6cvpRv+dqHs8cd+ldkVL3tHT00Cmh/vS7B5Mpg8ZnJF9NkRpsQ==", "38fcf561-10b6-4a69-a3b6-876811fbe5d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce759c03-d077-41c0-8512-5288136f7811", new DateTime(2022, 11, 26, 14, 6, 27, 768, DateTimeKind.Local).AddTicks(4971), "AQAAAAEAACcQAAAAEAOMz+WrV7Vg80qb9fV7FYmtJwQZupC+DpdGoKfTbr29M9FgXdk7n4GxjlPdKtY1yg==", "12553aa0-c6d6-4c98-8362-2b1ff68a2cff" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_Author",
                table: "Comments",
                column: "Author",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
