using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdatingEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FkChangesMadeByUserId",
                table: "UserAudits");

            migrationBuilder.DropForeignKey(
                name: "FkUserChangedId",
                table: "UserAudits");

            migrationBuilder.DropForeignKey(
                name: "FkVotationChangesMadeByUserId",
                table: "VotationAudit");

            migrationBuilder.DropIndex(
                name: "IX_VotationAudit_ChangesMadeByUserUserId",
                table: "VotationAudit");

            migrationBuilder.DropIndex(
                name: "IX_UserAudits_ChangesMadeByUserUserId",
                table: "UserAudits");

            migrationBuilder.DropIndex(
                name: "IX_UserAudits_UserChangedUserId",
                table: "UserAudits");

            migrationBuilder.DropColumn(
                name: "ChangesMadeByUserUserId",
                table: "VotationAudit");

            migrationBuilder.DropColumn(
                name: "ChangesMadeByUserUserId",
                table: "UserAudits");

            migrationBuilder.DropColumn(
                name: "UserChangedUserId",
                table: "UserAudits");

            migrationBuilder.AlterColumn<string>(
                name: "VotationTypeName",
                table: "VotationTypes",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "VotationTypeDescription",
                table: "VotationTypes",
                type: "varchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Votations",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "VotationStatusChangedTo",
                table: "VotationAudit",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusChangedAt",
                table: "VotationAudit",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "VotationAudit",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<int>(
                name: "ChangesMadeByUserId",
                table: "VotationAudit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Users",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Identification",
                table: "Users",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "StatusChangedTo",
                table: "UserAudits",
                type: "int",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusChangedAt",
                table: "UserAudits",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "LastPassword",
                table: "UserAudits",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLogin",
                table: "UserAudits",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "LastEmail",
                table: "UserAudits",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAudits",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeMadeAt",
                table: "UserAudits",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<int>(
                name: "ChangesMadeByUserId",
                table: "UserAudits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserChangedId",
                table: "UserAudits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "States",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rols",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PoliticalParties",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Abreviation",
                table: "PoliticalParties",
                type: "varchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Options",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Options",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Cities",
                type: "varchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Candidates",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Candidates",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Candidates",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Candidates",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusChangedAt",
                table: "CandidateAudits",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CandidateAudits",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<int>(
                name: "StatusChangedTo",
                table: "CandidateAudits",
                type: "int",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Nicaragua" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Boaco" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "Name", "StateId" },
                values: new object[] { 1, "361", "Boaco", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_VotationAudit_ChangesMadeByUserId",
                table: "VotationAudit",
                column: "ChangesMadeByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAudits_ChangesMadeByUserId",
                table: "UserAudits",
                column: "ChangesMadeByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAudits_UserChangedId",
                table: "UserAudits",
                column: "UserChangedId");

            migrationBuilder.AddForeignKey(
                name: "FkChangesMadeByUserId",
                table: "UserAudits",
                column: "ChangesMadeByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FkUserChangedId",
                table: "UserAudits",
                column: "UserChangedId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FkVotationChangesMadeByUserId",
                table: "VotationAudit",
                column: "ChangesMadeByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FkChangesMadeByUserId",
                table: "UserAudits");

            migrationBuilder.DropForeignKey(
                name: "FkUserChangedId",
                table: "UserAudits");

            migrationBuilder.DropForeignKey(
                name: "FkVotationChangesMadeByUserId",
                table: "VotationAudit");

            migrationBuilder.DropIndex(
                name: "IX_VotationAudit_ChangesMadeByUserId",
                table: "VotationAudit");

            migrationBuilder.DropIndex(
                name: "IX_UserAudits_ChangesMadeByUserId",
                table: "UserAudits");

            migrationBuilder.DropIndex(
                name: "IX_UserAudits_UserChangedId",
                table: "UserAudits");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ChangesMadeByUserId",
                table: "VotationAudit");

            migrationBuilder.DropColumn(
                name: "ChangesMadeByUserId",
                table: "UserAudits");

            migrationBuilder.DropColumn(
                name: "UserChangedId",
                table: "UserAudits");

            migrationBuilder.AlterColumn<string>(
                name: "VotationTypeName",
                table: "VotationTypes",
                type: "varchar",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "VotationTypeDescription",
                table: "VotationTypes",
                type: "varchar",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Votations",
                type: "varchar",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "VotationStatusChangedTo",
                table: "VotationAudit",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusChangedAt",
                table: "VotationAudit",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "VotationAudit",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChangesMadeByUserUserId",
                table: "VotationAudit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "varchar",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Users",
                type: "varchar",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "varchar",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Identification",
                table: "Users",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "varchar",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "StatusChangedTo",
                table: "UserAudits",
                type: "int",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusChangedAt",
                table: "UserAudits",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastPassword",
                table: "UserAudits",
                type: "varchar",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLogin",
                table: "UserAudits",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastEmail",
                table: "UserAudits",
                type: "varchar",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAudits",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeMadeAt",
                table: "UserAudits",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChangesMadeByUserUserId",
                table: "UserAudits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserChangedUserId",
                table: "UserAudits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "States",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rols",
                type: "varchar",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PoliticalParties",
                type: "varchar",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Abreviation",
                table: "PoliticalParties",
                type: "varchar",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Options",
                type: "varchar",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Options",
                type: "varchar",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Cities",
                type: "varchar",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Candidates",
                type: "varchar",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Candidates",
                type: "varchar",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Candidates",
                type: "varchar",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Candidates",
                type: "varchar",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusChangedAt",
                table: "CandidateAudits",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CandidateAudits",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusChangedTo",
                table: "CandidateAudits",
                type: "int",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VotationAudit_ChangesMadeByUserUserId",
                table: "VotationAudit",
                column: "ChangesMadeByUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAudits_ChangesMadeByUserUserId",
                table: "UserAudits",
                column: "ChangesMadeByUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAudits_UserChangedUserId",
                table: "UserAudits",
                column: "UserChangedUserId");

            migrationBuilder.AddForeignKey(
                name: "FkChangesMadeByUserId",
                table: "UserAudits",
                column: "ChangesMadeByUserUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FkUserChangedId",
                table: "UserAudits",
                column: "UserChangedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FkVotationChangesMadeByUserId",
                table: "VotationAudit",
                column: "ChangesMadeByUserUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
