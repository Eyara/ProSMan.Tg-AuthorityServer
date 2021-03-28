using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProSMan.Telegram.Infrastructure.Migrations
{
    public partial class RedesignDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCodes");

            migrationBuilder.CreateTable(
                name: "ApplicationClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationClientCodes",
                columns: table => new
                {
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    ApplicationClientId = table.Column<Guid>(maxLength: 20, nullable: false),
                    Code = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationClientCodes", x => new { x.ApplicationClientId, x.UserName });
                    table.ForeignKey(
                        name: "FK_ApplicationClientCodes_ApplicationClients_ApplicationClientId",
                        column: x => x.ApplicationClientId,
                        principalTable: "ApplicationClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientPermissions",
                columns: table => new
                {
                    ClientId = table.Column<string>(nullable: false),
                    ApplicationClientId = table.Column<Guid>(nullable: false),
                    Permission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPermissions", x => new { x.ApplicationClientId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_ClientPermissions_ApplicationClients_ApplicationClientId",
                        column: x => x.ApplicationClientId,
                        principalTable: "ApplicationClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientPermissions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientPermissions_ClientId",
                table: "ClientPermissions",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationClientCodes");

            migrationBuilder.DropTable(
                name: "ClientPermissions");

            migrationBuilder.DropTable(
                name: "ApplicationClients");

            migrationBuilder.CreateTable(
                name: "ClientCodes",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCodes", x => new { x.ClientId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ClientCodes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
