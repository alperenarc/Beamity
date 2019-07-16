using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beamity.EntityFrameworkCore.Migrations
{
    public partial class fixMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artifacts_Locations_LocationId",
                table: "Artifacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Artifacts_Rooms_RoomId",
                table: "Artifacts");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomId",
                table: "Artifacts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Artifacts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Artifacts_Locations_LocationId",
                table: "Artifacts",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artifacts_Rooms_RoomId",
                table: "Artifacts",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artifacts_Locations_LocationId",
                table: "Artifacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Artifacts_Rooms_RoomId",
                table: "Artifacts");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomId",
                table: "Artifacts",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Artifacts",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Artifacts_Locations_LocationId",
                table: "Artifacts",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artifacts_Rooms_RoomId",
                table: "Artifacts",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
