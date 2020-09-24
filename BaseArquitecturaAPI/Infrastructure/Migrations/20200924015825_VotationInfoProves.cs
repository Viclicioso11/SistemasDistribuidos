using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class VotationInfoProves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VotationTypeDescription",
                table: "VotationTypes",
                type: "varchar(200)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldMaxLength: 2);

            migrationBuilder.InsertData(
                table: "VotationTypes",
                columns: new[] { "Id", "VotationTypeDescription", "VotationTypeName" },
                values: new object[] { 1, "Votaciones municipales", "Alcaldía" });

            migrationBuilder.InsertData(
                table: "Votations",
                columns: new[] { "Id", "CityId", "Description", "EndDate", "StartDate", "Status", "VotationTypeId" },
                values: new object[] { 1, 1, "Votacion de pruebas", new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Votations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VotationTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "VotationTypeDescription",
                table: "VotationTypes",
                type: "varchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 2);
        }
    }
}
