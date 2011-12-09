namespace DungeonLog.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
using System.Data.Entity;

    /// <summary>
    /// Summary description for DungeonLogContext
    /// </summary>
    public class DungeonLogContext : DbContext
    {
        public DungeonLogContext() : base("DungeonLog") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                        .HasRequired(g => g.Owner)
                        .WithMany(g => g.OwnedGames);
        }

        public DbSet<DungeonMaster> DungeonMasters { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<User> Users { get; set; }
    }
}