using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace studyset.Migrations
{
    /// <inheritdoc />
    public partial class M03AddTableCronogramas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cronogramas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConteudoEstudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEstudo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cronogramas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cronogramas_Usuarios_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cronogramas_AlunoId",
                table: "Cronogramas",
                column: "AlunoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cronogramas");
        }
    }
}
