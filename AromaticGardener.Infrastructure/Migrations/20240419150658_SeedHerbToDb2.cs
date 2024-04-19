using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AromaticGardener.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedHerbToDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Herbs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Watering",
                value: "Water when topsoil is dry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Herbs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Watering",
                value: "");
        }
    }
}
