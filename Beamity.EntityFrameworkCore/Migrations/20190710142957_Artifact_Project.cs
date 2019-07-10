using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beamity.EntityFrameworkCore.Migrations
{
    public partial class Artifact_Project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Artifacts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artifacts_ProjectId",
                table: "Artifacts",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artifacts_Projects_ProjectId",
                table: "Artifacts",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artifacts_Projects_ProjectId",
                table: "Artifacts");

            migrationBuilder.DropIndex(
                name: "IX_Artifacts_ProjectId",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Artifacts");
        }
    }
}
