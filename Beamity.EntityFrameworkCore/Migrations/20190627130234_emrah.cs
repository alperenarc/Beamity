using Microsoft.EntityFrameworkCore.Migrations;

namespace Beamity.EntityFrameworkCore.Migrations
{
    public partial class emrah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "emrah",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emrah",
                table: "Rooms");
        }
    }
}
