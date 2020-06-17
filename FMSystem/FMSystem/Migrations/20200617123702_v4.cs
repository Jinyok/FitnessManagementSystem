using Microsoft.EntityFrameworkCore.Migrations;

namespace FMSystem.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "section",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_section_coach_CourseId",
                table: "section",
                column: "CourseId",
                principalTable: "coach",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_section_coach_CourseId",
                table: "section");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "section");
        }
    }
}
