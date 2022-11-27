using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class CourseMatchTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseMatches_CourseMatchId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_CourseMatches_CourseMatchId",
                table: "Students");

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

            migrationBuilder.CreateIndex(
                name: "IX_CourseMatches_CourseId",
                table: "CourseMatches",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMatches_StudentId",
                table: "CourseMatches",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMatches_Courses_CourseId",
                table: "CourseMatches",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMatches_Students_StudentId",
                table: "CourseMatches",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMatches_Courses_CourseId",
                table: "CourseMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseMatches_Students_StudentId",
                table: "CourseMatches");

            migrationBuilder.DropIndex(
                name: "IX_CourseMatches_CourseId",
                table: "CourseMatches");

            migrationBuilder.DropIndex(
                name: "IX_CourseMatches_StudentId",
                table: "CourseMatches");

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
    }
}
