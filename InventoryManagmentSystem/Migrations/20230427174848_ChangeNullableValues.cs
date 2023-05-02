using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagmentSystem.Migrations
{
    public partial class ChangeNullableValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_PersonInformation_PersonInformationId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInformation_LivingPlaceInformation_LivingPlaceInformationId",
                table: "PersonInformation");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "PersonInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PersonInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LivingPlaceInformationId",
                table: "PersonInformation",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "PersonInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "LivingPlaceInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "LivingPlaceInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonInformationId",
                table: "Account",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Account",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Account",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_PersonInformation_PersonInformationId",
                table: "Account",
                column: "PersonInformationId",
                principalTable: "PersonInformation",
                principalColumn: "PersonInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInformation_LivingPlaceInformation_LivingPlaceInformationId",
                table: "PersonInformation",
                column: "LivingPlaceInformationId",
                principalTable: "LivingPlaceInformation",
                principalColumn: "LivingPlaceInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_PersonInformation_PersonInformationId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInformation_LivingPlaceInformation_LivingPlaceInformationId",
                table: "PersonInformation");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "PersonInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PersonInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "LivingPlaceInformationId",
                table: "PersonInformation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "PersonInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "LivingPlaceInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "LivingPlaceInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonInformationId",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Account",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Account",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_PersonInformation_PersonInformationId",
                table: "Account",
                column: "PersonInformationId",
                principalTable: "PersonInformation",
                principalColumn: "PersonInformationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInformation_LivingPlaceInformation_LivingPlaceInformationId",
                table: "PersonInformation",
                column: "LivingPlaceInformationId",
                principalTable: "LivingPlaceInformation",
                principalColumn: "LivingPlaceInformationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
