﻿// <auto-generated />
using System;
using FMSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FMSystem.Migrations
{
    [DbContext(typeof(fmsContext))]
    [Migration("20200610211023_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FMSystem.Models.Coach", b =>
                {
                    b.Property<int>("CoachId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(45)");

                    b.Property<long?>("PhoneNo")
                        .HasColumnType("bigint");

                    b.HasKey("CoachId");

                    b.ToTable("coach");
                });

            modelBuilder.Entity("FMSystem.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClassHour")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CourseId");

                    b.ToTable("course");
                });

            modelBuilder.Entity("FMSystem.Models.Instructs", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<int>("AttendedHours")
                        .HasColumnType("int");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.HasKey("MemberId", "CoachId")
                        .HasName("PRIMARY");

                    b.HasIndex("CoachId")
                        .HasName("instruct_CoachID_idx");

                    b.ToTable("instructs");
                });

            modelBuilder.Entity("FMSystem.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(45)");

                    b.Property<long?>("PhoneNo")
                        .HasColumnType("bigint");

                    b.HasKey("MemberId");

                    b.ToTable("member");
                });

            modelBuilder.Entity("FMSystem.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("SectionId");

                    b.HasIndex("CourseId")
                        .HasName("section_CourseID_idx");

                    b.ToTable("section");
                });

            modelBuilder.Entity("FMSystem.Models.User", b =>
                {
                    b.Property<string>("Userid")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Userid");

                    b.ToTable("user");
                });

            modelBuilder.Entity("FMSystem.Models.Instructs", b =>
                {
                    b.HasOne("FMSystem.Models.Coach", "Coach")
                        .WithMany("Instructs")
                        .HasForeignKey("CoachId")
                        .IsRequired();

                    b.HasOne("FMSystem.Models.Member", "Member")
                        .WithMany("Instructs")
                        .HasForeignKey("MemberId")
                        .IsRequired();
                });

            modelBuilder.Entity("FMSystem.Models.Section", b =>
                {
                    b.HasOne("FMSystem.Models.Course", "Course")
                        .WithMany("Section")
                        .HasForeignKey("CourseId");
                });
#pragma warning restore 612, 618
        }
    }
}
