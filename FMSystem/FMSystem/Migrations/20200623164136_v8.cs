using Microsoft.EntityFrameworkCore.Migrations;

namespace FMSystem.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_course_CoachId",
                table: "Lesson");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_coach_CoachId",
                table: "Lesson",
                column: "CoachId",
                principalTable: "coach",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_coach_CoachId",
                table: "Lesson");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_course_CoachId",
                table: "Lesson",
                column: "CoachId",
                principalTable: "course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
