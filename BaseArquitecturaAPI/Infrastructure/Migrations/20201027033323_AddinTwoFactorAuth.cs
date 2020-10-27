using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddinTwoFactorAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TwoFactorAuthentications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OneTimePassword = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Attempts = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwoFactorAuthentications", x => x.Id);
                    table.ForeignKey(
                        name: "FkTFAUserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TwoFactorAuthentications_UserId",
                table: "TwoFactorAuthentications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TwoFactorAuthentications");
        }
    }
}
