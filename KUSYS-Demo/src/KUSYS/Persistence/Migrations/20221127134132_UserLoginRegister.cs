using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UserLoginRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperationClaimId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseMatchId",
                table: "Students",
                column: "CourseMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseMatchId",
                table: "Courses",
                column: "CourseMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");

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
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "User");

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
    }
}
