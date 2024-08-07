using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserImages_ImgId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImgId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("071ae3af-13aa-4885-8e32-7aeb5b439ef3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b4795a08-22f4-419f-b5fd-10b44993d01c"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("863596c7-c850-4b0b-a668-c3792b2c48ce"), new Guid("4ced5b48-49e2-4f52-84b0-5d7c5ac9301c") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("863596c7-c850-4b0b-a668-c3792b2c48ce"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4ced5b48-49e2-4f52-84b0-5d7c5ac9301c"));

            migrationBuilder.DropColumn(
                name: "ImgId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("9c95394a-5c05-4ddd-b9e4-10b25c99861a"), null, "Role", "Client", "Client" },
                    { new Guid("c61d53ea-1655-4cb2-b529-63d80567d8fa"), null, "Role", "Support Manager", "Support Manager" },
                    { new Guid("c8dad606-c313-4882-8d8b-67d7bd982f3e"), null, "Role", "Support Team Member", "Support Team Member" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Path", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("9c3c5f27-8e0f-43af-9fdd-ebd3d4f218a3"), 0, "T2", new DateOnly(2024, 8, 7), "067e2fb9-1851-45ef-b4e6-739eae976fb6", "admin@Admin.com", true, "Admin", "Admin", false, null, "admin@Admin.com", "admin", "AKkz/tSNtOxKVO2uIMQH+bUzCxXCu0EgVF4UE6ugRHxQ4rTKkovC48HGAnFxTLvnew==", "Test", "000000000", true, "f990b79d-5b1a-48b6-91aa-b3e8720f4378", 1, true, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("c61d53ea-1655-4cb2-b529-63d80567d8fa"), new Guid("9c3c5f27-8e0f-43af-9fdd-ebd3d4f218a3") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c95394a-5c05-4ddd-b9e4-10b25c99861a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c8dad606-c313-4882-8d8b-67d7bd982f3e"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c61d53ea-1655-4cb2-b529-63d80567d8fa"), new Guid("9c3c5f27-8e0f-43af-9fdd-ebd3d4f218a3") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c61d53ea-1655-4cb2-b529-63d80567d8fa"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9c3c5f27-8e0f-43af-9fdd-ebd3d4f218a3"));

            migrationBuilder.DropColumn(
                name: "Path",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "ImgId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    ImgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => x.ImgId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("071ae3af-13aa-4885-8e32-7aeb5b439ef3"), null, "Role", "Support Team Member", "Support Team Member" },
                    { new Guid("863596c7-c850-4b0b-a668-c3792b2c48ce"), null, "Role", "Support Manager", "Support Manager" },
                    { new Guid("b4795a08-22f4-419f-b5fd-10b44993d01c"), null, "Role", "Client", "Client" }
                });

            migrationBuilder.InsertData(
                table: "UserImages",
                columns: new[] { "ImgId", "Path", "UserId" },
                values: new object[] { new Guid("befb3bf0-d4a3-492b-826d-00114bcac9fa"), "Test", new Guid("4ced5b48-49e2-4f52-84b0-5d7c5ac9301c") });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImgId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4ced5b48-49e2-4f52-84b0-5d7c5ac9301c"), 0, "T2", new DateOnly(2024, 8, 7), "9e0ac0d5-8d2b-4e2c-9f73-b24c3463e78e", "admin@Admin.com", true, "Admin", new Guid("befb3bf0-d4a3-492b-826d-00114bcac9fa"), "Admin", false, null, "admin@Admin.com", "admin", "AMdCzCJIkDfphWbY82dC+uxk4bnG0GdNBj5GU9uTiPdBVAvdUIYrWKKRrXa5KdI1TQ==", "000000000", true, "ebafa127-28ef-4d28-adb7-300e0e4e46cb", 1, true, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("863596c7-c850-4b0b-a668-c3792b2c48ce"), new Guid("4ced5b48-49e2-4f52-84b0-5d7c5ac9301c") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImgId",
                table: "AspNetUsers",
                column: "ImgId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserImages_ImgId",
                table: "AspNetUsers",
                column: "ImgId",
                principalTable: "UserImages",
                principalColumn: "ImgId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
