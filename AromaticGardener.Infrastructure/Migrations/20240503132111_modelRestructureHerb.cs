using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AromaticGardener.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modelRestructureHerb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "Herbs");

            migrationBuilder.DropColumn(
                name: "Division",
                table: "Herbs");

            migrationBuilder.DropColumn(
                name: "Family",
                table: "Herbs");

            migrationBuilder.DropColumn(
                name: "Genus",
                table: "Herbs");

            migrationBuilder.DropColumn(
                name: "Kingdom",
                table: "Herbs");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Herbs");

            migrationBuilder.DropColumn(
                name: "Species",
                table: "Herbs");

            migrationBuilder.DropColumn(
                name: "Subclass",
                table: "Herbs");

            migrationBuilder.DropColumn(
                name: "Subkingdom",
                table: "Herbs");

            migrationBuilder.DropColumn(
                name: "Superdivision",
                table: "Herbs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Herbs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Division",
                table: "Herbs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Family",
                table: "Herbs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genus",
                table: "Herbs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kingdom",
                table: "Herbs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Order",
                table: "Herbs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Species",
                table: "Herbs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Subclass",
                table: "Herbs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subkingdom",
                table: "Herbs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Superdivision",
                table: "Herbs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Herbs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Class", "Division", "Family", "Genus", "Kingdom", "Order", "Species", "Subclass", "Subkingdom", "Superdivision" },
                values: new object[] { "Magnoliopsida", "Magnoliophyta", "Lamiaceae", "Origanum", "Plantae", "Lamiales", "Origanum vulgare", "", "", "" });
        }
    }
}
