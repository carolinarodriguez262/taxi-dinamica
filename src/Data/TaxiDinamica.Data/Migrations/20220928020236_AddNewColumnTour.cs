using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiDinamica.Data.Migrations
{
    public partial class AddNewColumnTour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNormalTour",
                table: "Tours",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNormalTour",
                table: "Tours");
        }
    }
}
