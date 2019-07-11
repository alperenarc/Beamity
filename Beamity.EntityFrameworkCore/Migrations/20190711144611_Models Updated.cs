using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beamity.EntityFrameworkCore.Migrations
{
    public partial class ModelsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beacons_Projects_ProjectId",
                table: "Beacons");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Projects_ProjectId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Contents",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_ProjectId",
                table: "Contents",
                newName: "IX_Contents_LocationId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Beacons",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Beacons_ProjectId",
                table: "Beacons",
                newName: "IX_Beacons_LocationId");

            migrationBuilder.AddColumn<Guid>(
                name: "BeaconId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCampaign",
                table: "Contents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Artifacts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BeaconId",
                table: "Rooms",
                column: "BeaconId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserId",
                table: "Locations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Artifacts_LocationId",
                table: "Artifacts",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artifacts_Locations_LocationId",
                table: "Artifacts",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Beacons_Locations_LocationId",
                table: "Beacons",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Locations_LocationId",
                table: "Contents",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Users_UserId",
                table: "Locations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Beacons_BeaconId",
                table: "Rooms",
                column: "BeaconId",
                principalTable: "Beacons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artifacts_Locations_LocationId",
                table: "Artifacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Beacons_Locations_LocationId",
                table: "Beacons");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Locations_LocationId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Users_UserId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Beacons_BeaconId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_BeaconId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Locations_UserId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Artifacts_LocationId",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "BeaconId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "IsCampaign",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Artifacts");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Contents",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_LocationId",
                table: "Contents",
                newName: "IX_Contents_ProjectId");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Beacons",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Beacons_LocationId",
                table: "Beacons",
                newName: "IX_Beacons_ProjectId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beacons_Projects_ProjectId",
                table: "Beacons",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Projects_ProjectId",
                table: "Contents",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
