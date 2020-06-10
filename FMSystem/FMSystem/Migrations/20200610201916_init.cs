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
                    CoachID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    PhoneNo = table.Column<long>(nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coach", x => x.CoachID);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    Cost = table.Column<int>(nullable: false),
                    ClassHour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "member",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PhoneNo = table.Column<long>(nullable: true),
                    Name = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_member", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userid = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    password = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    create_time = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "section",
                columns: table => new
                {
                    SectionID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseID = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_section", x => x.SectionID);
                    table.ForeignKey(
                        name: "section_CourseID",
                        column: x => x.CourseID,
                        principalTable: "course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "instructs",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false),
                    CoachID = table.Column<int>(nullable: false),
                    AttendedHours = table.Column<int>(nullable: false),
                    TotalHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.MemberID, x.CoachID });
                    table.ForeignKey(
                        name: "instruct_CoachID",
                        column: x => x.CoachID,
                        principalTable: "coach",
                        principalColumn: "CoachID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "instruct_MemberID",
                        column: x => x.MemberID,
                        principalTable: "member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "instruct_CoachID_idx",
                table: "instructs",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "section_CourseID_idx",
                table: "section",
                column: "CourseID");
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
