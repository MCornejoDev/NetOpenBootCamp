using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApiBackend.Migrations
{
    public partial class AddnewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndexId",
                table: "Curso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Index",
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
                    table.PrimaryKey("PK_Index", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curso_IndexId",
                table: "Curso",
                column: "IndexId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Index_IndexId",
                table: "Curso",
                column: "IndexId",
                principalTable: "Index",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Index_IndexId",
                table: "Curso");

            migrationBuilder.DropTable(
                name: "Index");

            migrationBuilder.DropIndex(
                name: "IX_Curso_IndexId",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "IndexId",
                table: "Curso");
        }
    }
}
