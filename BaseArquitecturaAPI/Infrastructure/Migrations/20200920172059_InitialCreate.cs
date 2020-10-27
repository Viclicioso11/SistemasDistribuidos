using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoliticalParties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    Abreviation = table.Column<string>(type: "varchar", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticalParties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identification = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    Surname = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VotationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VotationTypeName = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    VotationTypeDescription = table.Column<string>(type: "varchar", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FkCountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    Surname = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    PoliticalPartyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FkPoliticalPartyId",
                        column: x => x.PoliticalPartyId,
                        principalTable: "PoliticalParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(nullable: false),
                    OptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FkOptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FkRolId",
                        column: x => x.RolId,
                        principalTable: "Rols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangesMadeByUserId = table.Column<int>(nullable: false),
                    StatusChangedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusChangedTo = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FkCandidateChangesMadeByUserId",
                        column: x => x.ChangesMadeByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusChangedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusChangedTo = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    LastPassword = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    LastEmail = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: false),
                    ChangeMadeAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserChangedUserId = table.Column<int>(nullable: false),
                    ChangesMadeByUserUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FkChangesMadeByUserId",
                        column: x => x.ChangesMadeByUserUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FkUserChangedId",
                        column: x => x.UserChangedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRols", x => x.Id);
                    table.ForeignKey(
                        name: "FkURolId",
                        column: x => x.RolId,
                        principalTable: "Rols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FkRUserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FkStateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FkCandidateVoteId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FkUserVoteId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VotationTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FkVotationTypeId",
                        column: x => x.VotationTypeId,
                        principalTable: "VotationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotationAudit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusChangedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ChangesMadeByUserUserId = table.Column<int>(nullable: false),
                    VotationStatusChangedTo = table.Column<int>(type: "int", nullable: false),
                    VotationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotationAudit", x => x.Id);
                    table.ForeignKey(
                        name: "FkVotationChangesMadeByUserId",
                        column: x => x.ChangesMadeByUserUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FkVotationId",
                        column: x => x.VotationId,
                        principalTable: "Votations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VotationDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VotationId = table.Column<int>(nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FkCandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FkDVotationId",
                        column: x => x.VotationId,
                        principalTable: "Votations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoteAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    VotationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FkVAUserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FkAVotationId",
                        column: x => x.VotationId,
                        principalTable: "Votations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAudits_ChangesMadeByUserId",
                table: "CandidateAudits",
                column: "ChangesMadeByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_PoliticalPartyId",
                table: "Candidates",
                column: "PoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_RolOptions_OptionId",
                table: "RolOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolOptions_RolId",
                table: "RolOptions",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAudits_ChangesMadeByUserUserId",
                table: "UserAudits",
                column: "ChangesMadeByUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAudits_UserChangedUserId",
                table: "UserAudits",
                column: "UserChangedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRols_RolId",
                table: "UserRols",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRols_UserId",
                table: "UserRols",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VotationAudit_ChangesMadeByUserUserId",
                table: "VotationAudit",
                column: "ChangesMadeByUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VotationAudit_VotationId",
                table: "VotationAudit",
                column: "VotationId");

            migrationBuilder.CreateIndex(
                name: "IX_VotationDetail_CandidateId",
                table: "VotationDetail",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_VotationDetail_VotationId",
                table: "VotationDetail",
                column: "VotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Votations_CityId",
                table: "Votations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Votations_VotationTypeId",
                table: "Votations",
                column: "VotationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteAudits_UserId",
                table: "VoteAudits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteAudits_VotationId",
                table: "VoteAudits",
                column: "VotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CandidateId",
                table: "Votes",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateAudits");

            migrationBuilder.DropTable(
                name: "RolOptions");

            migrationBuilder.DropTable(
                name: "UserAudits");

            migrationBuilder.DropTable(
                name: "UserRols");

            migrationBuilder.DropTable(
                name: "VotationAudit");

            migrationBuilder.DropTable(
                name: "VotationDetail");

            migrationBuilder.DropTable(
                name: "VoteAudits");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropTable(
                name: "Votations");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "VotationTypes");

            migrationBuilder.DropTable(
                name: "PoliticalParties");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
