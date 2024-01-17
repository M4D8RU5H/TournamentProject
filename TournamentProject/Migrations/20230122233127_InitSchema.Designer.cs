﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TournamentProject.Models;

#nullable disable

namespace TournamentProject.Migrations
{
    [DbContext(typeof(TournamentDbContext))]
    [Migration("20230122233127_InitSchema")]
    partial class InitSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TournamentProject.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CommentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 1, 22, 23, 31, 27, 182, DateTimeKind.Utc).AddTicks(1912));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TournamentProject.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FirstTeamId")
                        .HasColumnType("int");

                    b.Property<int>("Phase")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("SecondTeamId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstTeamId");

                    b.HasIndex("SecondTeamId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("TournamentProject.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 1, 22, 23, 31, 27, 182, DateTimeKind.Utc).AddTicks(2287));

                    b.Property<bool>("Readed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TournamentProject.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(750)
                        .HasColumnType("nvarchar(750)");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 1, 22, 23, 31, 27, 182, DateTimeKind.Utc).AddTicks(2831));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("TournamentProject.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Category")
                        .HasMaxLength(40)
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 1, 22, 23, 31, 27, 182, DateTimeKind.Utc).AddTicks(3362));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("TournamentProject.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Ratio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TournamentProject.Models.TeamUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamUser");
                });

            modelBuilder.Entity("TournamentProject.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(750)
                        .HasColumnType("nvarchar(750)");

                    b.Property<string>("LiveTransmisionEmbed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxTeamAmount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("RegistrationEnds")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RegistrationStarts")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TournamentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("TournamentProject.Models.TournamentTeam", b =>
                {
                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("TournamentId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("TournamentTeam");
                });

            modelBuilder.Entity("TournamentProject.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BannedUntill")
                        .HasColumnType("datetime2");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TournamentProject.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("TournamentProject.Models.Comment", b =>
                {
                    b.HasOne("TournamentProject.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentProject.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TournamentProject.Models.Match", b =>
                {
                    b.HasOne("TournamentProject.Models.Team", "FirstTeam")
                        .WithMany()
                        .HasForeignKey("FirstTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TournamentProject.Models.Team", "SecondTeam")
                        .WithMany()
                        .HasForeignKey("SecondTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TournamentProject.Models.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentProject.Models.Team", "WinnerTeam")
                        .WithMany()
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FirstTeam");

                    b.Navigation("SecondTeam");

                    b.Navigation("Tournament");

                    b.Navigation("WinnerTeam");
                });

            modelBuilder.Entity("TournamentProject.Models.Message", b =>
                {
                    b.HasOne("TournamentProject.Models.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TournamentProject.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TournamentProject.Models.User", null)
                        .WithMany("Messages")
                        .HasForeignKey("UserId");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("TournamentProject.Models.Post", b =>
                {
                    b.HasOne("TournamentProject.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TournamentProject.Models.Report", b =>
                {
                    b.HasOne("TournamentProject.Models.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TournamentProject.Models.TeamUser", b =>
                {
                    b.HasOne("TournamentProject.Models.Team", "Team")
                        .WithMany("Team_Users")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentProject.Models.User", "User")
                        .WithMany("Team_Users")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TournamentProject.Models.TournamentTeam", b =>
                {
                    b.HasOne("TournamentProject.Models.Team", "Team")
                        .WithMany("Tournament_Teams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentProject.Models.Tournament", "Tournament")
                        .WithMany("Tournament_Teams")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("TournamentProject.Models.User", b =>
                {
                    b.HasOne("TournamentProject.Models.UserRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TournamentProject.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("TournamentProject.Models.Team", b =>
                {
                    b.Navigation("Team_Users");

                    b.Navigation("Tournament_Teams");
                });

            modelBuilder.Entity("TournamentProject.Models.Tournament", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("Tournament_Teams");
                });

            modelBuilder.Entity("TournamentProject.Models.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Reports");

                    b.Navigation("Team_Users");
                });

            modelBuilder.Entity("TournamentProject.Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}