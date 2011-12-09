namespace DungeonLog.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Player
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}