using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace EfProjectionWithTopologyError.Migrations
{
    public partial class Initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthInstitutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coordinates = table.Column<Point>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthInstitutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthInstitutionMedicalServiceLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthInstitutionId = table.Column<int>(type: "int", nullable: false),
                    MedicalServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthInstitutionMedicalServiceLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthInstitutionMedicalServiceLinks_HealthInstitutions_HealthInstitutionId",
                        column: x => x.HealthInstitutionId,
                        principalTable: "HealthInstitutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthInstitutionMedicalServiceLinks_MedicalServices_MedicalServiceId",
                        column: x => x.MedicalServiceId,
                        principalTable: "MedicalServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthInstitutionMedicalServiceLinks_HealthInstitutionId",
                table: "HealthInstitutionMedicalServiceLinks",
                column: "HealthInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthInstitutionMedicalServiceLinks_MedicalServiceId",
                table: "HealthInstitutionMedicalServiceLinks",
                column: "MedicalServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthInstitutionMedicalServiceLinks");

            migrationBuilder.DropTable(
                name: "HealthInstitutions");

            migrationBuilder.DropTable(
                name: "MedicalServices");
        }
    }
}
