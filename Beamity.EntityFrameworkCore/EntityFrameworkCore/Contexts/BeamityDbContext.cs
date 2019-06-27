using Beamity.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts
{
    public class BeamityDbContext: DbContext
    {
        public BeamityDbContext(DbContextOptions<BeamityDbContext> options)
            : base(options)
        {   
        }
        public DbSet<Artifact> Artifacts { get; set; }
        public DbSet<Beacon> Beacons { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        
    }
}
