using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMSystem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coach",
                columns: table => new
                {
                    CoachId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", nullable: true),
                    PhoneNo = table.Column<long>(nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coach", x => x.CoachId);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    ClassHour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "member",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PhoneNo = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Userid = table.Column<string>(type: "varchar(30)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(30)", nullable: true),
                    Password = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Userid);
                });

            migrationBuilder.CreateTable(
                name: "section",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_section", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_section_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "instructs",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false),
                    CoachId = table.Column<int>(nullable: false),
                    AttendedHours = table.Column<int>(nullable: false),
                    TotalHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.MemberId, x.CoachId });
                    table.ForeignKey(
                        name: "FK_instructs_coach_CoachId",
                        column: x => x.CoachId,
                        principalTable: "coach",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_instructs_member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "instruct_CoachID_idx",
                table: "instructs",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "section_CourseID_idx",
                table: "section",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "instructs");

            migrationBuilder.DropTable(
                name: "section");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "coach");

            migrationBuilder.DropTable(
                name: "member");

            migrationBuilder.DropTable(
                name: "course");
        }
    }
}
