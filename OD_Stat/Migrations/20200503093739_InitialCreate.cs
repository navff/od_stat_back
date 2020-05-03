using Microsoft.EntityFrameworkCore.Migrations;

namespace OD_Stat.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FiasId = table.Column<string>(nullable: false),
                    UnrestrictedValue = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: false),
                    RegionFiasId = table.Column<string>(nullable: false),
                    Settlement = table.Column<string>(nullable: false),
                    SettlementFiasId = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    CityFiasId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DirectorUserId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    ParentDivisionId = table.Column<int>(nullable: true),
                    DivisionType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divisions_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Divisions_Divisions_ParentDivisionId",
                        column: x => x.ParentDivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DivisionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_AddressId",
                table: "Divisions",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_DirectorUserId",
                table: "Divisions",
                column: "DirectorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ParentDivisionId",
                table: "Divisions",
                column: "ParentDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DivisionId",
                table: "Users",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Users_DirectorUserId",
                table: "Divisions",
                column: "DirectorUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Addresses_AddressId",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Users_DirectorUserId",
                table: "Divisions");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Divisions");
        }
    }
}
