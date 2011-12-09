using System;
using System.Collections.Generic;
using System.Web;
using System.Web.WebPages;
using WebMatrix.Data;
using WebMatrix.WebData;
using System.Net;

public enum GamePermission
{
    Owner = 0,
    DM = 1,
    Player = 2,
    None = 3
}

public static class Permissions
{
    public static HttpContextBase Context
    {
        get { return WebPageContext.Current.Page.Context; }
    }

    public static GamePermission GetGamePermission(dynamic game)
    {
        return GetGamePermission(game.OwnerUserId, game.Id);
    }

    public static GamePermission GetGamePermission(int ownerId, int gameId)
    {
        if (ownerId == WebSecurity.CurrentUserId)
        {
            return GamePermission.Owner;
        }
        Database db = Database.Open("DungeonLog");
        var dm = db.QuerySingle("SELECT * FROM DungeonMasters WHERE GameId = @0 AND UserId = @1", gameId, WebSecurity.CurrentUserId);
        if (dm != null)
        {
            return GamePermission.DM;
        }
        var player = db.QuerySingle("SELECT * FROM Players WHERE GameId = @0 AND UserId = @1", gameId, WebSecurity.CurrentUserId);
        if (player != null)
        {
            return GamePermission.Player;
        }
        return GamePermission.None;
    }

    public static bool IsAtLeast(dynamic game, GamePermission required)
    {
        return IsAtLeast(GetGamePermission(game), required);
    }

    public static bool IsAtLeast(GamePermission has, GamePermission required)
    {
        return has <= required;
    }

    public static void RequireAtLeast(dynamic game, GamePermission required)
    {
        GamePermission perm = GetGamePermission(game);
        RequireAtLeast(perm, required);
    }

    public static void RequireAtLeast(GamePermission has, GamePermission required)
    {
        if (!IsAtLeast(has, required))
        {
            Context.Response.SetStatus(HttpStatusCode.Unauthorized);
        }
    }

    public static void RequireExactly(dynamic game, GamePermission required)
    {
        GamePermission perm = GetGamePermission(game);
        RequireExactly(perm, required);
    }

    public static void RequireExactly(GamePermission has, GamePermission required)
    {
        if (has != required)
        {
            Context.Response.SetStatus(HttpStatusCode.Unauthorized);
        }
    }
}
