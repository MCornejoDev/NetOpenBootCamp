using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApiBackend.Migrations
{
    public partial class UpdateModelChapter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Chapters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Chapters");
        }
    }
}
