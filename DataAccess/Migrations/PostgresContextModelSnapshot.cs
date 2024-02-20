﻿// <auto-generated />
using System;
using DataAcces.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(PostgresContext))]
    partial class PostgresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Model.ExperimentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LabModelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("LabModelId");

                    b.ToTable("ExperimentModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description",
                            LabModelId = 1,
                            Name = "Name",
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Data.Model.LabModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LessonModelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LessonModelId");

                    b.ToTable("LabModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description",
                            LessonModelId = 1,
                            Name = "Name"
                        });
                });

            modelBuilder.Entity("Data.Model.LessonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserModelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserModelId");

                    b.ToTable("LessonModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description",
                            Name = "Name",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Data.Model.StudentToExperiment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExperimentId")
                        .HasColumnType("integer");

                    b.Property<int?>("ExperimentModelId")
                        .HasColumnType("integer");

                    b.Property<string>("QrCodeText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExperimentModelId");

                    b.ToTable("StudentToExperiment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExperimentId = 1,
                            QrCodeText = "",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Data.Model.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AppRegisterToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppRegisterToken = " ",
                            Email = "S",
                            Name = "Name",
                            Number = "055",
                            Password = "S",
                            Phone = " ",
                            Surname = "S",
                            UserType = 0
                        });
                });

            modelBuilder.Entity("Data.Model.ExperimentModel", b =>
                {
                    b.HasOne("Data.Model.LabModel", "LabModel")
                        .WithMany()
                        .HasForeignKey("LabModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LabModel");
                });

            modelBuilder.Entity("Data.Model.LabModel", b =>
                {
                    b.HasOne("Data.Model.LessonModel", "LessonModel")
                        .WithMany()
                        .HasForeignKey("LessonModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LessonModel");
                });

            modelBuilder.Entity("Data.Model.LessonModel", b =>
                {
                    b.HasOne("Data.Model.UserModel", "UserModel")
                        .WithMany()
                        .HasForeignKey("UserModelId");

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("Data.Model.StudentToExperiment", b =>
                {
                    b.HasOne("Data.Model.ExperimentModel", "ExperimentModel")
                        .WithMany()
                        .HasForeignKey("ExperimentModelId");

                    b.Navigation("ExperimentModel");
                });
#pragma warning restore 612, 618
        }
    }
}
