using Microsoft.EntityFrameworkCore.Migrations;

namespace Beamity.EntityFrameworkCore.Migrations
{
    public partial class deleted_emrah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emrah",
                table: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "emrah",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);
        }
    }
}
