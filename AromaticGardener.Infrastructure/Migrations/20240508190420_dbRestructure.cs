using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AromaticGardener.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dbRestructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrowthHabits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Habit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrowthHabits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LifeCycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cycle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeCycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Herbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScientificName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bloom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestSoilType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoilPhMin = table.Column<double>(type: "float", nullable: false),
                    SoilPhMax = table.Column<double>(type: "float", nullable: false),
                    Watering = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insulation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrowthHabitId = table.Column<int>(type: "int", nullable: false),
                    LifeCycleId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Herbs_GrowthHabits_GrowthHabitId",
                        column: x => x.GrowthHabitId,
                        principalTable: "GrowthHabits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Herbs_LifeCycles_LifeCycleId",
                        column: x => x.LifeCycleId,
                        principalTable: "LifeCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GrowthHabits",
                columns: new[] { "Id", "Habit" },
                values: new object[,]
                {
                    { 1, "Herb" },
                    { 2, "Shrub" },
                    { 3, "Tree" },
                    { 4, "Vine" }
                });

            migrationBuilder.InsertData(
                table: "LifeCycles",
                columns: new[] { "Id", "Cycle" },
                values: new object[,]
                {
                    { 1, "Annual" },
                    { 2, "Biennial" },
                    { 3, "Perennial" }
                });

            migrationBuilder.InsertData(
                table: "Herbs",
                columns: new[] { "Id", "BestSoilType", "Bloom", "CommonName", "Description", "GrowthHabitId", "ImageUrl", "Insulation", "LifeCycleId", "ScientificName", "SoilPhMax", "SoilPhMin", "Watering" },
                values: new object[] { 1, "Well-drained soil", "Summer", "Oregano", "Perennial herbaceous plant of the mint family, characterized by opposite, aromatic leaves and purple flowers.", 1, "", "Full", 1, "Origanum Vulgare", 7.0, 6.5, "Water when topsoil is dry" });

            migrationBuilder.CreateIndex(
                name: "IX_Herbs_GrowthHabitId",
                table: "Herbs",
                column: "GrowthHabitId");

            migrationBuilder.CreateIndex(
                name: "IX_Herbs_LifeCycleId",
                table: "Herbs",
                column: "LifeCycleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Herbs");

            migrationBuilder.DropTable(
                name: "GrowthHabits");

            migrationBuilder.DropTable(
                name: "LifeCycles");
        }
    }
}
