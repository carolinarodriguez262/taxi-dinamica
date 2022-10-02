using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiDinamica.Data.Migrations
{
    public partial class NewChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Indentity = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    DateAdmission = table.Column<DateTime>(nullable: false),
                    Tipe = table.Column<string>(nullable: true),
                    Frequency = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_IsDeleted",
                table: "Parameters",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parameters");
        }
    }
}
