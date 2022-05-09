using Microsoft.EntityFrameworkCore.Migrations;

namespace Coterie.Data.DatabaseMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    BusinessId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Factor = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.BusinessId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Factor = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "BusinessId", "Factor", "Name" },
                values: new object[] { 1, 1.0, "Architect" });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "BusinessId", "Factor", "Name" },
                values: new object[] { 2, 0.5, "Plumber" });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "BusinessId", "Factor", "Name" },
                values: new object[] { 3, 1.25, "Programmer" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "Code", "Factor", "Name" },
                values: new object[] { 1, "OH", 1.0, "OHIO" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "Code", "Factor", "Name" },
                values: new object[] { 2, "FL", 1.2, "FLORIDA" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "Code", "Factor", "Name" },
                values: new object[] { 3, "TX", 0.94299999999999995, "TEXAS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
