using System;
using System.Collections.Generic;
using System.Web;
using WebMatrix.Data;
using WebMatrix.WebData;

public enum GamePermission {
    Owner,
    DM,
    Player,
    None
}

public static class Permissions
{
    public static GamePermission GetGamePermission(dynamic game) {
        if(game.OwnerUserId == WebSecurity.CurrentUserId) {
            return GamePermission.Owner;
        }
        Database db = Database.Open("DungeonLog");
        var player = db.QuerySingle("SELECT * FROM Players WHERE GameId = @0 AND UserId = @1", game.Id, WebSecurity.CurrentUserId);
        if(player != null) {
            return GamePermission.Player;
        }
        var dm = db.QuerySingle("SELECT * FROM DungeonMasters WHERE GameId = @0 AND UserId = @1", game.Id, WebSecurity.CurrentUserId);
        if(dm != null) {
            return GamePermission.DM;
        }
        return GamePermission.None;
    }   
}
