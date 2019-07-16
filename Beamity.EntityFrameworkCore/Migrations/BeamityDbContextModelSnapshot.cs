﻿// <auto-generated />
using System;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Beamity.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(BeamityDbContext))]
    partial class BeamityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Beamity.Core.Models.Artifact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsActive");

                    b.Property<Guid>("LocationId");

                    b.Property<string>("MainImageURL")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(47);

                    b.Property<Guid>("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("RoomId");

                    b.ToTable("Artifacts");
                });

            modelBuilder.Entity("Beamity.Core.Models.Beacon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("LocationId");

                    b.Property<int>("Major");

                    b.Property<int>("Minor");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UUID")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Beacons");
                });

            modelBuilder.Entity("Beamity.Core.Models.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("LocationId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("Beamity.Core.Models.Content", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AudioURL");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsCampaign");

                    b.Property<bool>("IsHomePage");

                    b.Property<Guid?>("LocationId");

                    b.Property<string>("MainImageURL")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(47);

                    b.Property<string>("SlideImageURL");

                    b.Property<string>("Text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(65);

                    b.Property<string>("VideoURL");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("Beamity.Core.Models.Floor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BuildingId");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("Beamity.Core.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Latitude")
                        .IsRequired();

                    b.Property<string>("Longitude")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhotoURL");

                    b.Property<Guid?>("ProjectId");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Beamity.Core.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Beamity.Core.Models.Relation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ArtifactId");

                    b.Property<Guid?>("BeaconId");

                    b.Property<Guid?>("ContentId");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("LocationId");

                    b.Property<int>("Proximity");

                    b.HasKey("Id");

                    b.HasIndex("ArtifactId");

                    b.HasIndex("BeaconId");

                    b.HasIndex("ContentId");

                    b.HasIndex("LocationId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("Beamity.Core.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Beamity.Core.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BeaconId");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<Guid?>("FloorId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(47);

                    b.HasKey("Id");

                    b.HasIndex("BeaconId");

                    b.HasIndex("FloorId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Beamity.Core.Models.Statistics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BeaconId");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsActive");

                    b.HasKey("Id");

                    b.HasIndex("BeaconId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("Beamity.Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Hash");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("RoleName");

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Beamity.Core.Models.Artifact", b =>
                {
                    b.HasOne("Beamity.Core.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Beamity.Core.Models.Room", "Room")
                        .WithMany("Artifacts")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Beamity.Core.Models.Beacon", b =>
                {
                    b.HasOne("Beamity.Core.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("Beamity.Core.Models.Building", b =>
                {
                    b.HasOne("Beamity.Core.Models.Location", "Location")
                        .WithMany("Buildings")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("Beamity.Core.Models.Content", b =>
                {
                    b.HasOne("Beamity.Core.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("Beamity.Core.Models.Floor", b =>
                {
                    b.HasOne("Beamity.Core.Models.Building", "Building")
                        .WithMany("Floors")
                        .HasForeignKey("BuildingId");
                });

            modelBuilder.Entity("Beamity.Core.Models.Location", b =>
                {
                    b.HasOne("Beamity.Core.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("Beamity.Core.Models.User", "User")
                        .WithMany("Locations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Beamity.Core.Models.Relation", b =>
                {
                    b.HasOne("Beamity.Core.Models.Artifact", "Artifact")
                        .WithMany()
                        .HasForeignKey("ArtifactId");

                    b.HasOne("Beamity.Core.Models.Beacon", "Beacon")
                        .WithMany()
                        .HasForeignKey("BeaconId");

                    b.HasOne("Beamity.Core.Models.Content", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId");

                    b.HasOne("Beamity.Core.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("Beamity.Core.Models.Room", b =>
                {
                    b.HasOne("Beamity.Core.Models.Beacon", "Beacon")
                        .WithMany()
                        .HasForeignKey("BeaconId");

                    b.HasOne("Beamity.Core.Models.Floor", "Floor")
                        .WithMany("Rooms")
                        .HasForeignKey("FloorId");
                });

            modelBuilder.Entity("Beamity.Core.Models.Statistics", b =>
                {
                    b.HasOne("Beamity.Core.Models.Beacon", "Beacon")
                        .WithMany()
                        .HasForeignKey("BeaconId");
                });
#pragma warning restore 612, 618
        }
    }
}
