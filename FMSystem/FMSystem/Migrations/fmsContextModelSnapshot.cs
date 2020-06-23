﻿// <auto-generated />
using System;
using FMSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FMSystem.Migrations
{
    [DbContext(typeof(fmsContext))]
    partial class fmsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FMSystem.Entity.fms.Coach", b =>
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

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("CoachId");

                    b.ToTable("coach");
                });

            modelBuilder.Entity("FMSystem.Entity.fms.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClassHour")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(45)");

                    b.HasKey("CourseId");

                    b.ToTable("course");
                });

            modelBuilder.Entity("FMSystem.Entity.fms.Instructs", b =>
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

            modelBuilder.Entity("FMSystem.Entity.fms.Lesson", b =>
                {
                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<int>("LessonNo")
                        .HasColumnType("int");

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("EndDate")
                        .HasColumnType("DATETIME");

                    b.Property<DateTimeOffset?>("StartDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("SectionId", "LessonNo");

                    b.HasIndex("CoachId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("FMSystem.Entity.fms.Member", b =>
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

            modelBuilder.Entity("FMSystem.Entity.fms.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("SectionId");

                    b.HasIndex("CourseId")
                        .HasName("section_CourseID_idx");

                    b.ToTable("section");
                });

            modelBuilder.Entity("FMSystem.Entity.fms.Takes", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("MemberId", "SectionId")
                        .HasName("PRIMARY");

                    b.HasIndex("SectionId");

                    b.ToTable("takes");
                });

            modelBuilder.Entity("FMSystem.Entity.fms.User", b =>
                {
                    b.Property<long>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Userid");

                    b.ToTable("user");
                });

            modelBuilder.Entity("FMSystem.Entity.fms.Instructs", b =>
                {
                    b.HasOne("FMSystem.Entity.fms.Coach", "Coach")
                        .WithMany("Instructs")
                        .HasForeignKey("CoachId")
                        .IsRequired();

                    b.HasOne("FMSystem.Entity.fms.Member", "Member")
                        .WithMany("Instructs")
                        .HasForeignKey("MemberId")
                        .IsRequired();
                });

            modelBuilder.Entity("FMSystem.Entity.fms.Lesson", b =>
                {
                    b.HasOne("FMSystem.Entity.fms.Course", null)
                        .WithMany()
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FMSystem.Entity.fms.Section", null)
                        .WithMany("Lesson")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FMSystem.Entity.fms.Section", b =>
                {
                    b.HasOne("FMSystem.Entity.fms.Coach", "Coach")
                        .WithMany("Sections")
                        .HasForeignKey("CourseId");

                    b.HasOne("FMSystem.Entity.fms.Course", "Course")
                        .WithMany("Section")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("FMSystem.Entity.fms.Takes", b =>
                {
                    b.HasOne("FMSystem.Entity.fms.Member", "Member")
                        .WithMany("Takes")
                        .HasForeignKey("MemberId")
                        .IsRequired();

                    b.HasOne("FMSystem.Entity.fms.Section", "Section")
                        .WithMany("Takes")
                        .HasForeignKey("SectionId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
