using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beamity.EntityFrameworkCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beacons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UUID = table.Column<string>(nullable: false),
                    Major = table.Column<int>(nullable: false),
                    Minor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beacons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 47, nullable: false),
                    Title = table.Column<string>(maxLength: 65, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    MainImageURL = table.Column<string>(nullable: false),
                    SlideImageURL = table.Column<string>(nullable: true),
                    VideoURL = table.Column<string>(nullable: true),
                    AudioURL = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    IsHomePage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Hash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Latitude = table.Column<string>(nullable: false),
                    Longitude = table.Column<string>(nullable: false),
                    ProjetId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    LocationId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Locations_LocationId1",
                        column: x => x.LocationId1,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false),
                    BuildingId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floors_Buildings_BuildingId1",
                        column: x => x.BuildingId1,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 47, nullable: false),
                    FloorId = table.Column<int>(nullable: false),
                    FloorId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Floors_FloorId1",
                        column: x => x.FloorId1,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artifacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 47, nullable: false),
                    MainImageURL = table.Column<string>(nullable: false),
                    RoomId = table.Column<int>(nullable: true),
                    RoomId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artifacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artifacts_Rooms_RoomId1",
                        column: x => x.RoomId1,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ArtifactId = table.Column<int>(nullable: false),
                    ArtifactId1 = table.Column<Guid>(nullable: true),
                    ContentId = table.Column<int>(nullable: false),
                    ContentId1 = table.Column<Guid>(nullable: true),
                    BeaconId = table.Column<int>(nullable: true),
                    BeaconId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relations_Artifacts_ArtifactId1",
                        column: x => x.ArtifactId1,
                        principalTable: "Artifacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_Beacons_BeaconId1",
                        column: x => x.BeaconId1,
                        principalTable: "Beacons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_Contents_ContentId1",
                        column: x => x.ContentId1,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artifacts_RoomId1",
                table: "Artifacts",
                column: "RoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_LocationId1",
                table: "Buildings",
                column: "LocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_BuildingId1",
                table: "Floors",
                column: "BuildingId1");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ProjectId",
                table: "Locations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_ArtifactId1",
                table: "Relations",
                column: "ArtifactId1");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_BeaconId1",
                table: "Relations",
                column: "BeaconId1");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_ContentId1",
                table: "Relations",
                column: "ContentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FloorId1",
                table: "Rooms",
                column: "FloorId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Artifacts");

            migrationBuilder.DropTable(
                name: "Beacons");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
