namespace DungeonLog.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<DungeonMaster> DungeonMasters { get; set; }
        public virtual ICollection<Game> OwnedGames { get; set; }
    }
}