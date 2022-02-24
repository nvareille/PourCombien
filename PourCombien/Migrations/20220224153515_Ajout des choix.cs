using Microsoft.EntityFrameworkCore.Migrations;

namespace PourCombien.Migrations
{
    public partial class Ajoutdeschoix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Choix1",
                table: "Defis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Choix2",
                table: "Defis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Choix1",
                table: "Defis");

            migrationBuilder.DropColumn(
                name: "Choix2",
                table: "Defis");
        }
    }
}
