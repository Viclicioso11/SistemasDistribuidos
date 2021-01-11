using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addingVotationIdToVote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VotationId",
                table: "Votes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VotationId",
                table: "Votes",
                column: "VotationId");

            migrationBuilder.AddForeignKey(
                name: "FkVotationVoteId",
                table: "Votes",
                column: "VotationId",
                principalTable: "Votations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FkVotationVoteId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_VotationId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "VotationId",
                table: "Votes");
        }
    }
}
