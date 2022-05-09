using Microsoft.EntityFrameworkCore.Migrations;

namespace PolicyService.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumerPolicies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pid = table.Column<long>(type: "bigint", nullable: false),
                    ConsumerId = table.Column<long>(type: "bigint", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssuredSum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessValue = table.Column<long>(type: "bigint", nullable: false),
                    PropertyValue = table.Column<long>(type: "bigint", nullable: false),
                    BaseLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcceptedQuote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyMasters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssuredSum = table.Column<double>(type: "float", nullable: false),
                    Tenure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessValue = table.Column<long>(type: "bigint", nullable: false),
                    PropertyValue = table.Column<long>(type: "bigint", nullable: false),
                    BaseLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyMasters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PolicyMasters",
                columns: new[] { "Id", "AssuredSum", "BaseLocation", "BusinessValue", "ConsumerType", "PropertyType", "PropertyValue", "Tenure", "Type" },
                values: new object[] { "P01", 400000.0, "Chennai", 8L, "Owner", "Building", 5L, "3 year", "Replacement" });

            migrationBuilder.InsertData(
                table: "PolicyMasters",
                columns: new[] { "Id", "AssuredSum", "BaseLocation", "BusinessValue", "ConsumerType", "PropertyType", "PropertyValue", "Tenure", "Type" },
                values: new object[] { "P02", 20000000.0, "Chennai", 9L, "Owner", "Factory Equipment", 10L, "1 year", "Replacement" });

            migrationBuilder.InsertData(
                table: "PolicyMasters",
                columns: new[] { "Id", "AssuredSum", "BaseLocation", "BusinessValue", "ConsumerType", "PropertyType", "PropertyValue", "Tenure", "Type" },
                values: new object[] { "P03", 200000.0, "Pune", 7L, "Owner", "Property in Transit", 8L, "1 week", "Pay Back" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumerPolicies");

            migrationBuilder.DropTable(
                name: "PolicyMasters");
        }
    }
}
