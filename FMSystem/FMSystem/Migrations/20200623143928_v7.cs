using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMSystem.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coursearrangement");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "section");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "section");

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false),
                    LessonNo = table.Column<int>(nullable: false),
                    CoachId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "DATETIME", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "DATETIME", nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => new { x.SectionId, x.LessonNo });
                    table.ForeignKey(
                        name: "FK_Lesson_course_CoachId",
                        column: x => x.CoachId,
                        principalTable: "course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lesson_section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_CoachId",
                table: "Lesson",
                column: "CoachId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "section",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "section",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "coursearrangement",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseNo = table.Column<int>(type: "int", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.CourseId, x.CourseNo });
                    table.ForeignKey(
                        name: "FK_coursearrangement_coach_CoachId",
                        column: x => x.CoachId,
                        principalTable: "coach",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_coursearrangement_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_coursearrangement_CoachId",
                table: "coursearrangement",
                column: "CoachId");
        }
    }
}
