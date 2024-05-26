using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AromaticGardener.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HerbKitSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HerbKits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HerbId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HerbKits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HerbKits_Herbs_HerbId",
                        column: x => x.HerbId,
                        principalTable: "Herbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HerbKits",
                columns: new[] { "Id", "Description", "HerbId", "Name", "Price", "Stock" },
                values: new object[] { 1, "Includes seeds for growing oregano.", 1, "Basic Herb Kit", 9.9900000000000002, 50 });

            migrationBuilder.UpdateData(
                table: "Herbs",
                keyColumn: "Id",
                keyValue: 1,
                column: "LifeCycleId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_HerbKits_HerbId",
                table: "HerbKits",
                column: "HerbId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HerbKits");

            migrationBuilder.UpdateData(
                table: "Herbs",
                keyColumn: "Id",
                keyValue: 1,
                column: "LifeCycleId",
                value: 1);
        }
    }
}
