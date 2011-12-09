namespace DungeonLog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DungeonLog.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DungeonLogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
