using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApiBackend.Migrations
{
    public partial class UpdateNewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Index_IndexId",
                table: "Curso");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoStudent_Student_StudentsId",
                table: "CursoStudent");

            migrationBuilder.DropTable(
                name: "Index");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameColumn(
                name: "IndexId",
                table: "Curso",
                newName: "ChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_Curso_IndexId",
                table: "Curso",
                newName: "IX_Curso_ChapterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Chapters_ChapterId",
                table: "Curso",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoStudent_Students_StudentsId",
                table: "CursoStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Chapters_ChapterId",
                table: "Curso");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoStudent_Students_StudentsId",
                table: "CursoStudent");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameColumn(
                name: "ChapterId",
                table: "Curso",
                newName: "IndexId");

            migrationBuilder.RenameIndex(
                name: "IX_Curso_ChapterId",
                table: "Curso",
                newName: "IX_Curso_IndexId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Index",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Index", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Index_IndexId",
                table: "Curso",
                column: "IndexId",
                principalTable: "Index",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoStudent_Student_StudentsId",
                table: "CursoStudent",
                column: "StudentsId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
