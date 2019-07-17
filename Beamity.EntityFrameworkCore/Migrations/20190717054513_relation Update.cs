using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beamity.EntityFrameworkCore.Migrations
{
    public partial class relationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Artifacts_ArtifactId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Beacons_BeaconId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Contents_ContentId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Locations_LocationId",
                table: "Relations");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Relations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ContentId",
                table: "Relations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BeaconId",
                table: "Relations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtifactId",
                table: "Relations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Artifacts_ArtifactId",
                table: "Relations",
                column: "ArtifactId",
                principalTable: "Artifacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Beacons_BeaconId",
                table: "Relations",
                column: "BeaconId",
                principalTable: "Beacons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Contents_ContentId",
                table: "Relations",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Locations_LocationId",
                table: "Relations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Artifacts_ArtifactId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Beacons_BeaconId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Contents_ContentId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Locations_LocationId",
                table: "Relations");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Relations",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ContentId",
                table: "Relations",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "BeaconId",
                table: "Relations",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtifactId",
                table: "Relations",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Artifacts_ArtifactId",
                table: "Relations",
                column: "ArtifactId",
                principalTable: "Artifacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Beacons_BeaconId",
                table: "Relations",
                column: "BeaconId",
                principalTable: "Beacons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Contents_ContentId",
                table: "Relations",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Locations_LocationId",
                table: "Relations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
