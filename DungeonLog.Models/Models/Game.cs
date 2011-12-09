namespace DungeonLog.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Game
    {
        public int Id { get; set; }
        public int OwnerUserId { get; set; }
        public string Name { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<DungeonMaster> DungeonMasters { get; set; }
    }
}