using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beamity.EntityFrameworkCore.Migrations
{
    public partial class nullableartifact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Artifacts_ArtifactId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Beacons_BeaconId",
                table: "Statistics");

            migrationBuilder.AlterColumn<Guid>(
                name: "BeaconId",
                table: "Statistics",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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
                name: "FK_Statistics_Beacons_BeaconId",
                table: "Statistics",
                column: "BeaconId",
                principalTable: "Beacons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Artifacts_ArtifactId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Beacons_BeaconId",
                table: "Statistics");

            migrationBuilder.AlterColumn<Guid>(
                name: "BeaconId",
                table: "Statistics",
                nullable: true,
                oldClrType: typeof(Guid));

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
                name: "FK_Statistics_Beacons_BeaconId",
                table: "Statistics",
                column: "BeaconId",
                principalTable: "Beacons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
