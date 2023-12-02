using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace studyset.Migrations
{
    /// <inheritdoc />
    public partial class MCronograma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEstudo",
                table: "Cronogramas");

            migrationBuilder.AddColumn<int>(
                name: "DiaEstudo",
                table: "Cronogramas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaEstudo",
                table: "Cronogramas");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEstudo",
                table: "Cronogramas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
