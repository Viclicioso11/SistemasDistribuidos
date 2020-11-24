using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class votationTypeStateAndCityDefect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Options",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 16, 1, "Defecto" });

            migrationBuilder.InsertData(
                table: "VotationTypes",
                columns: new[] { "Id", "VotationTypeDescription", "VotationTypeName" },
                values: new object[] { 2, "Votación nacional", "Presidencial" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "Name", "StateId" },
                values: new object[] { 134, "0", "DefectoNicaragua", 16 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "VotationTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Options",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);
        }
    }
}
