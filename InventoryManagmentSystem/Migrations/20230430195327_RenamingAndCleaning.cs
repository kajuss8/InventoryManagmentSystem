using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagmentSystem.Migrations
{
    public partial class RenamingAndCleaning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "PersonInformation");

            migrationBuilder.DropTable(
                name: "LivingPlaceInformation");

            migrationBuilder.CreateTable(
                name: "LivingPlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    FlatNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    LivingPlaceInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LivingPlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInformation_LivingPlaces_LivingPlaceId",
                        column: x => x.LivingPlaceId,
                        principalTable: "LivingPlaces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UsersInformation_UserInformationId",
                        column: x => x.UserInformationId,
                        principalTable: "UsersInformation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserInformationId",
                table: "Users",
                column: "UserInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInformation_LivingPlaceId",
                table: "UsersInformation",
                column: "LivingPlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UsersInformation");

            migrationBuilder.DropTable(
                name: "LivingPlaces");

            migrationBuilder.CreateTable(
                name: "LivingPlaceInformation",
                columns: table => new
                {
                    LivingPlaceInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlatNumber = table.Column<int>(type: "int", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingPlaceInformation", x => x.LivingPlaceInformationId);
                });

            migrationBuilder.CreateTable(
                name: "PersonInformation",
                columns: table => new
                {
                    PersonInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LivingPlaceInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    ProfileImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInformation", x => x.PersonInformationId);
                    table.ForeignKey(
                        name: "FK_PersonInformation_LivingPlaceInformation_LivingPlaceInformationId",
                        column: x => x.LivingPlaceInformationId,
                        principalTable: "LivingPlaceInformation",
                        principalColumn: "LivingPlaceInformationId");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_PersonInformation_PersonInformationId",
                        column: x => x.PersonInformationId,
                        principalTable: "PersonInformation",
                        principalColumn: "PersonInformationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_PersonInformationId",
                table: "Account",
                column: "PersonInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInformation_LivingPlaceInformationId",
                table: "PersonInformation",
                column: "LivingPlaceInformationId");
        }
    }
}
