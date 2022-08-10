using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApiBackend.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Chapters_ChapterId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_ChapterId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "Course");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_CourseId",
                table: "Chapters",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Course_CourseId",
                table: "Chapters",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Course_CourseId",
                table: "Chapters");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_CourseId",
                table: "Chapters");

            migrationBuilder.AddColumn<int>(
                name: "ChapterId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Course_ChapterId",
                table: "Course",
                column: "ChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Chapters_ChapterId",
                table: "Course",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
