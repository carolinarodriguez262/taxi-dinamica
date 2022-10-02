using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiDinamica.Data.Migrations
{
    public partial class AddTablesTours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Day = table.Column<string>(nullable: true),
                    PartnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    TourStartTime = table.Column<TimeSpan>(nullable: false),
                    TourEndTime = table.Column<TimeSpan>(nullable: false),
                    TourStartAddress = table.Column<string>(nullable: true),
                    TourEndAddress = table.Column<string>(nullable: true),
                    DocTourUrl = table.Column<string>(nullable: true),
                    PartnerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tours_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Directions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    EstimatedStartTime = table.Column<TimeSpan>(nullable: false),
                    EstimatedEndTime = table.Column<TimeSpan>(nullable: false),
                    TourId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directions_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Directions_IsDeleted",
                table: "Directions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Directions_TourId",
                table: "Directions",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_IsDeleted",
                table: "Schedules",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_PartnerId",
                table: "Schedules",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_IsDeleted",
                table: "Tours",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_PartnerId",
                table: "Tours",
                column: "PartnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directions");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
