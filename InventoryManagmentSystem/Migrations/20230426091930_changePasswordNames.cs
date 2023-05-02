using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagmentSystem.Migrations
{
    public partial class changePasswordNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Account");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Account",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Account",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
