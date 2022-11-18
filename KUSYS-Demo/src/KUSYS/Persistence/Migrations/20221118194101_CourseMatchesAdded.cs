using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class CourseMatchesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseMatchId",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseMatchId",
                table: "Courses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMatches", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseMatchId",
                table: "Students",
                column: "CourseMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseMatchId",
                table: "Courses",
                column: "CourseMatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseMatches_CourseMatchId",
                table: "Courses",
                column: "CourseMatchId",
                principalTable: "CourseMatches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_CourseMatches_CourseMatchId",
                table: "Students",
                column: "CourseMatchId",
                principalTable: "CourseMatches",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseMatches_CourseMatchId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_CourseMatches_CourseMatchId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "CourseMatches");

            migrationBuilder.DropIndex(
                name: "IX_Students_CourseMatchId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseMatchId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseMatchId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseMatchId",
                table: "Courses");
        }
    }
}
