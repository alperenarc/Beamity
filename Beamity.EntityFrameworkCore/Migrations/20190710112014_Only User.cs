using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beamity.EntityFrameworkCore.Migrations
{
    public partial class OnlyUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Relations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Contents",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Beacons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Relations_ProjectId",
                table: "Relations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_ProjectId",
                table: "Contents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Beacons_ProjectId",
                table: "Beacons",
                column: "ProjectId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Projects_ProjectId",
                table: "Relations",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Projects_ProjectId",
                table: "Relations");

            migrationBuilder.DropIndex(
                name: "IX_Relations_ProjectId",
                table: "Relations");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Contents_ProjectId",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Beacons_ProjectId",
                table: "Beacons");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Relations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Beacons");
        }
    }
}
