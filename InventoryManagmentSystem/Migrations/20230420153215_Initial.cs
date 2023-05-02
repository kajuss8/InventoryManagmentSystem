using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagmentSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LivingPlaceInformation",
                columns: table => new
                {
                    LivingPlaceInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    FlatNumber = table.Column<int>(type: "int", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivingPlaceInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInformation", x => x.PersonInformationId);
                    table.ForeignKey(
                        name: "FK_PersonInformation_LivingPlaceInformation_LivingPlaceInformationId",
                        column: x => x.LivingPlaceInformationId,
                        principalTable: "LivingPlaceInformation",
                        principalColumn: "LivingPlaceInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_PersonInformation_PersonInformationId",
                        column: x => x.PersonInformationId,
                        principalTable: "PersonInformation",
                        principalColumn: "PersonInformationId",
                        onDelete: ReferentialAction.Cascade);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "PersonInformation");

            migrationBuilder.DropTable(
                name: "LivingPlaceInformation");
        }
    }
}
