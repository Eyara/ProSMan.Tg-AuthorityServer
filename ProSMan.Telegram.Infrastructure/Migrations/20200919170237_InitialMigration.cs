using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProSMan.Telegram.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 20, nullable: false),
                    Secret = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientCodes",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<string>(maxLength: 20, nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCodes");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
