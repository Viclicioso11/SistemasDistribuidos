﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200924015825_VotationInfoProves")]
    partial class VotationInfoProves
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Candidate", b =>
                {
                    b.Property<int>("CandidateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnName("MiddleName")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<int>("PoliticalPartyId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnName("Status")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnName("Surname")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("CandidateId");

                    b.HasIndex("PoliticalPartyId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("Domain.Entities.CandidateAudit", b =>
                {
                    b.Property<int>("CandidateAuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidateStatusChangedTo")
                        .HasColumnName("StatusChangedTo")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.Property<int?>("ChangesMadeByUserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnName("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("StatusChangedAt")
                        .HasColumnName("StatusChangedAt")
                        .HasColumnType("datetime");

                    b.HasKey("CandidateAuditId");

                    b.HasIndex("ChangesMadeByUserId");

                    b.ToTable("CandidateAudits");
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityCode")
                        .IsRequired()
                        .HasColumnName("Code")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CityCode = "361",
                            CityName = "Boaco",
                            StateId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "Nicaragua"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Option", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OptionDescription")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("OptionName")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("OptionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Domain.Entities.PoliticalParty", b =>
                {
                    b.Property<int>("PoliticalPartyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviation")
                        .IsRequired()
                        .HasColumnName("Abreviation")
                        .HasColumnType("varchar(6)")
                        .HasMaxLength(6);

                    b.Property<string>("PoliticalPartyName")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("PoliticalPartyId");

                    b.ToTable("PoliticalParties");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RolName")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("RolId");

                    b.ToTable("Rols");
                });

            modelBuilder.Entity("Domain.Entities.RolOption", b =>
                {
                    b.Property<int>("RolOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("RolOptionId");

                    b.HasIndex("OptionId");

                    b.HasIndex("RolId");

                    b.ToTable("RolOptions");
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("StateId");

                    b.HasIndex("CountryId");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            StateId = 1,
                            CountryId = 1,
                            StateName = "Boaco"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnName("Identification")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnName("MiddleName")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Status")
                        .HasColumnName("Status")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnName("Surname")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.UserAudit", b =>
                {
                    b.Property<int>("UserAuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ChangeMadeAt")
                        .HasColumnName("ChangeMadeAt")
                        .HasColumnType("datetime");

                    b.Property<int>("ChangesMadeByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnName("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("LastEmail")
                        .HasColumnName("LastEmail")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnName("LastLogin")
                        .HasColumnType("datetime");

                    b.Property<string>("LastPassword")
                        .HasColumnName("LastPassword")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("StatusChangedAt")
                        .HasColumnName("StatusChangedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("UserChangedId")
                        .HasColumnType("int");

                    b.Property<int?>("UserStatusChangedTo")
                        .HasColumnName("StatusChangedTo")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.HasKey("UserAuditId");

                    b.HasIndex("ChangesMadeByUserId");

                    b.HasIndex("UserChangedId");

                    b.ToTable("UserAudits");
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.Property<int>("UserRolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserRolId");

                    b.HasIndex("RolId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRols");
                });

            modelBuilder.Entity("Domain.Entities.Votation", b =>
                {
                    b.Property<int>("VotationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("VotationDescription")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("VotationEndDate")
                        .HasColumnName("EndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("VotationStartDate")
                        .HasColumnName("StartDate")
                        .HasColumnType("datetime");

                    b.Property<int>("VotationStatus")
                        .HasColumnName("Status")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.Property<int>("VotationTypeId")
                        .HasColumnType("int");

                    b.HasKey("VotationId");

                    b.HasIndex("CityId");

                    b.HasIndex("VotationTypeId");

                    b.ToTable("Votations");

                    b.HasData(
                        new
                        {
                            VotationId = 1,
                            CityId = 1,
                            VotationDescription = "Votacion de pruebas",
                            VotationEndDate = new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VotationStartDate = new DateTime(2020, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VotationStatus = 1,
                            VotationTypeId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.VotationAudit", b =>
                {
                    b.Property<int>("VotationAuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChangesMadeByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnName("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("StatusChangedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("VotationId")
                        .HasColumnType("int");

                    b.Property<int?>("VotationStatusChangedTo")
                        .HasColumnName("VotationStatusChangedTo")
                        .HasColumnType("int");

                    b.HasKey("VotationAuditId");

                    b.HasIndex("ChangesMadeByUserId");

                    b.HasIndex("VotationId");

                    b.ToTable("VotationAudit");
                });

            modelBuilder.Entity("Domain.Entities.VotationDetail", b =>
                {
                    b.Property<int>("VotationDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("VotationId")
                        .HasColumnType("int");

                    b.HasKey("VotationDetailId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("VotationId");

                    b.ToTable("VotationDetail");
                });

            modelBuilder.Entity("Domain.Entities.VotationType", b =>
                {
                    b.Property<int>("VotationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VotationTypeDescription")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(2);

                    b.Property<string>("VotationTypeName")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("VotationTypeId");

                    b.ToTable("VotationTypes");

                    b.HasData(
                        new
                        {
                            VotationTypeId = 1,
                            VotationTypeDescription = "Votaciones municipales",
                            VotationTypeName = "Alcaldía"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Vote", b =>
                {
                    b.Property<int>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("VoteId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("UserId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Domain.Entities.VoteAudit", b =>
                {
                    b.Property<int>("VoteAuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VotationId")
                        .HasColumnType("int");

                    b.HasKey("VoteAuditId");

                    b.HasIndex("UserId");

                    b.HasIndex("VotationId");

                    b.ToTable("VoteAudits");
                });

            modelBuilder.Entity("Domain.Entities.Candidate", b =>
                {
                    b.HasOne("Domain.Entities.PoliticalParty", "PoliticalParty")
                        .WithMany("Candidates")
                        .HasForeignKey("PoliticalPartyId")
                        .HasConstraintName("FkPoliticalPartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.CandidateAudit", b =>
                {
                    b.HasOne("Domain.Entities.User", "ChangesMadeByUser")
                        .WithMany("CandidateAudits")
                        .HasForeignKey("ChangesMadeByUserId")
                        .HasConstraintName("FkCandidateChangesMadeByUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.HasOne("Domain.Entities.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .HasConstraintName("FkStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.RolOption", b =>
                {
                    b.HasOne("Domain.Entities.Option", "Option")
                        .WithMany("RolOptions")
                        .HasForeignKey("OptionId")
                        .HasConstraintName("FkOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("RolOptions")
                        .HasForeignKey("RolId")
                        .HasConstraintName("FkRolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.HasOne("Domain.Entities.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FkCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.UserAudit", b =>
                {
                    b.HasOne("Domain.Entities.User", "ChangesMadeByUser")
                        .WithMany("UserThatChangeAudits")
                        .HasForeignKey("ChangesMadeByUserId")
                        .HasConstraintName("FkChangesMadeByUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "UserChanged")
                        .WithMany("UserChangedAudits")
                        .HasForeignKey("UserChangedId")
                        .HasConstraintName("FkUserChangedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("UserRols")
                        .HasForeignKey("RolId")
                        .HasConstraintName("FkURolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserRols")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FkRUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Votation", b =>
                {
                    b.HasOne("Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.VotationType", "VotationType")
                        .WithMany("Votations")
                        .HasForeignKey("VotationTypeId")
                        .HasConstraintName("FkVotationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.VotationAudit", b =>
                {
                    b.HasOne("Domain.Entities.User", "ChangesMadeByUser")
                        .WithMany("VotationAudits")
                        .HasForeignKey("ChangesMadeByUserId")
                        .HasConstraintName("FkVotationChangesMadeByUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Votation", "Votation")
                        .WithMany("VotationAudits")
                        .HasForeignKey("VotationId")
                        .HasConstraintName("FkVotationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.VotationDetail", b =>
                {
                    b.HasOne("Domain.Entities.Candidate", "Candidate")
                        .WithMany("VotationDetails")
                        .HasForeignKey("CandidateId")
                        .HasConstraintName("FkCandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Votation", "Votation")
                        .WithMany("VotationDetails")
                        .HasForeignKey("VotationId")
                        .HasConstraintName("FkDVotationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Vote", b =>
                {
                    b.HasOne("Domain.Entities.Candidate", "Candidate")
                        .WithMany("Votes")
                        .HasForeignKey("CandidateId")
                        .HasConstraintName("FkCandidateVoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Votes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FkUserVoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.VoteAudit", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("VoteAudits")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FkVAUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Votation", "Votation")
                        .WithMany("VoteAudits")
                        .HasForeignKey("VotationId")
                        .HasConstraintName("FkAVotationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
