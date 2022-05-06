using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsumerService.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessMasters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessAge = table.Column<long>(type: "bigint", nullable: false),
                    TotalEmployee = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PanDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyMasters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingAge = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessTurnOver = table.Column<long>(type: "bigint", nullable: false),
                    CapitalInvested = table.Column<long>(type: "bigint", nullable: false),
                    TotalEmployee = table.Column<long>(type: "bigint", nullable: false),
                    BusinessValue = table.Column<long>(type: "bigint", nullable: false),
                    BusinessAge = table.Column<long>(type: "bigint", nullable: false),
                    ConsumerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessDetails_ConsumerDetails_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "ConsumerDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingSqft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingStoreys = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingAge = table.Column<long>(type: "bigint", nullable: false),
                    PropertyValue = table.Column<long>(type: "bigint", nullable: false),
                    CostoftheAsset = table.Column<long>(type: "bigint", nullable: false),
                    UseFulLifeOfTheAsset = table.Column<long>(type: "bigint", nullable: false),
                    SalvageValue = table.Column<long>(type: "bigint", nullable: false),
                    BusinessId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyDetails_BusinessDetails_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "BusinessDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDetails_ConsumerId",
                table: "BusinessDetails",
                column: "ConsumerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetails_BusinessId",
                table: "PropertyDetails",
                column: "BusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessMasters");

            migrationBuilder.DropTable(
                name: "PropertyDetails");

            migrationBuilder.DropTable(
                name: "PropertyMasters");

            migrationBuilder.DropTable(
                name: "BusinessDetails");

            migrationBuilder.DropTable(
                name: "ConsumerDetails");
        }
    }
}
