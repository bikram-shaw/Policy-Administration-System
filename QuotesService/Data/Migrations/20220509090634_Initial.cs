using Microsoft.EntityFrameworkCore.Migrations;

namespace QuotesService.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuotesMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessValue = table.Column<long>(type: "bigint", nullable: false),
                    PropertyValue = table.Column<long>(type: "bigint", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotesMaster", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "QuotesMaster",
                columns: new[] { "Id", "BusinessValue", "PropertyType", "PropertyValue", "Quotes" },
                values: new object[] { 1L, 10L, "Inventory", 5L, "30000" });

            migrationBuilder.InsertData(
                table: "QuotesMaster",
                columns: new[] { "Id", "BusinessValue", "PropertyType", "PropertyValue", "Quotes" },
                values: new object[] { 2L, 7L, "Equipment", 10L, "45000" });

            migrationBuilder.InsertData(
                table: "QuotesMaster",
                columns: new[] { "Id", "BusinessValue", "PropertyType", "PropertyValue", "Quotes" },
                values: new object[] { 3L, 5L, "Equipment", 8L, "80000" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuotesMaster");
        }
    }
}
