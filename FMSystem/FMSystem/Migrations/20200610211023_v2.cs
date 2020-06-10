using Microsoft.EntityFrameworkCore.Migrations;

namespace FMSystem.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "instruct_CoachID",
                table: "instructs");

            migrationBuilder.DropForeignKey(
                name: "instruct_MemberID",
                table: "instructs");

            migrationBuilder.DropForeignKey(
                name: "section_CourseID",
                table: "section");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "user",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "user",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "create_time",
                table: "user",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "section",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "SectionID",
                table: "section",
                newName: "SectionId");

            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "member",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "CoachID",
                table: "instructs",
                newName: "CoachId");

            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "instructs",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "course",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "CoachID",
                table: "coach",
                newName: "CoachId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "user",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Userid",
                table: "user",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "member",
                type: "varchar(45)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "course",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "coach",
                type: "varchar(45)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "coach",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_instructs_coach_CoachId",
                table: "instructs",
                column: "CoachId",
                principalTable: "coach",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_instructs_member_MemberId",
                table: "instructs",
                column: "MemberId",
                principalTable: "member",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_section_course_CourseId",
                table: "section",
                column: "CourseId",
                principalTable: "course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructs_coach_CoachId",
                table: "instructs");

            migrationBuilder.DropForeignKey(
                name: "FK_instructs_member_MemberId",
                table: "instructs");

            migrationBuilder.DropForeignKey(
                name: "FK_section_course_CourseId",
                table: "section");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "user",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "user",
                newName: "create_time");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "section",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "section",
                newName: "SectionID");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "member",
                newName: "MemberID");

            migrationBuilder.RenameColumn(
                name: "CoachId",
                table: "instructs",
                newName: "CoachID");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "instructs",
                newName: "MemberID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "course",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "CoachId",
                table: "coach",
                newName: "CoachID");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "user",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "user",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "member",
                type: "varchar(45)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "course",
                type: "varchar(45)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "coach",
                type: "varchar(45)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "coach",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddForeignKey(
                name: "instruct_CoachID",
                table: "instructs",
                column: "CoachID",
                principalTable: "coach",
                principalColumn: "CoachID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "instruct_MemberID",
                table: "instructs",
                column: "MemberID",
                principalTable: "member",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "section_CourseID",
                table: "section",
                column: "CourseID",
                principalTable: "course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
