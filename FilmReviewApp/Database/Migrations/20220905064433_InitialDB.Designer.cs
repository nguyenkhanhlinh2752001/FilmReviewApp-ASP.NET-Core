﻿// <auto-generated />
using System;
using FilmActorApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilmReviewApp.Database.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220905064433_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FilmReviewApp.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("FilmReviewApp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("FilmReviewApp.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("FilmReviewApp.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("FilmReviewApp.Models.FilmActor", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("FilmActor");
                });

            modelBuilder.Entity("FilmReviewApp.Models.FilmCategory", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("FilmCategory");
                });

            modelBuilder.Entity("FilmReviewApp.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("FilmReviewApp.Models.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reviewer");
                });

            modelBuilder.Entity("FilmReviewApp.Models.Actor", b =>
                {
                    b.HasOne("FilmReviewApp.Models.Country", "Country")
                        .WithMany("Actors")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FilmReviewApp.Models.FilmActor", b =>
                {
                    b.HasOne("FilmReviewApp.Models.Actor", "Actor")
                        .WithMany("FilmActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmReviewApp.Models.Film", "Film")
                        .WithMany("FilmActors")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("FilmReviewApp.Models.FilmCategory", b =>
                {
                    b.HasOne("FilmReviewApp.Models.Category", "Category")
                        .WithMany("FilmCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmReviewApp.Models.Film", "Film")
                        .WithMany("FilmCategories")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("FilmReviewApp.Models.Review", b =>
                {
                    b.HasOne("FilmReviewApp.Models.Film", "Film")
                        .WithMany("Reviews")
                        .HasForeignKey("FilmId");

                    b.HasOne("FilmReviewApp.Models.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId");

                    b.Navigation("Film");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("FilmReviewApp.Models.Actor", b =>
                {
                    b.Navigation("FilmActors");
                });

            modelBuilder.Entity("FilmReviewApp.Models.Category", b =>
                {
                    b.Navigation("FilmCategories");
                });

            modelBuilder.Entity("FilmReviewApp.Models.Country", b =>
                {
                    b.Navigation("Actors");
                });

            modelBuilder.Entity("FilmReviewApp.Models.Film", b =>
                {
                    b.Navigation("FilmActors");

                    b.Navigation("FilmCategories");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("FilmReviewApp.Models.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
