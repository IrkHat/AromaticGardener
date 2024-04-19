using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AromaticGardener.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedHerbToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Herbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bloom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestSoilType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoilPhMin = table.Column<double>(type: "float", nullable: false),
                    SoilPhMax = table.Column<double>(type: "float", nullable: false),
                    Watering = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insulation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrowthHabit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeCycle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kingdom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subkingdom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Superdivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subclass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herbs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Herbs",
                columns: new[] { "Id", "BestSoilType", "Bloom", "Class", "CommonName", "Description", "Division", "Family", "Genus", "GrowthHabit", "ImageUrl", "Insulation", "Kingdom", "LifeCycle", "Order", "SoilPhMax", "SoilPhMin", "Species", "Subclass", "Subkingdom", "Superdivision", "Watering" },
                values: new object[] { 1, "Well-drained", "Summer", "Magnoliopsida", "Oregano", "Perennial herbaceous plant of the mint family, characterized by opposite, aromatic leaves and purple flowers.", "Magnoliophyta", "Lamiaceae", "Origanum", "Herb", "", "Full", "Plantae", "Perennial", "Lamiales", 7.0, 6.5, "Origanum vulgare", "", "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Herbs");
        }
    }
}
