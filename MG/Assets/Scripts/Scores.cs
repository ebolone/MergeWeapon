using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour
{
    public const string PlayerKillScore = "Kill";
    public const string PlayerDeathScore = "Death";

    public static void AddKill(Player player, int scoreToAddToCurrent)
    {
        int current = GetKills(player);
        if (current == -1)
        {
            current = 0;
        }
        current = current + scoreToAddToCurrent;

        Hashtable score = new Hashtable();  // using PUN's implementation of Hashtable
        score[PlayerKillScore] = current;

        player.SetCustomProperties(score);  // this locally sets the score and will sync it in-game asap.
    }

    public static int GetKills(Player player)
    {
        object score;
        if (player.CustomProperties.TryGetValue(PlayerKillScore, out score))
        {
            return (int)score;
        }

        return 0;
    }
    public static void SetKills(Player player, int newScore)
    {
        Hashtable score = new Hashtable();  // using PUN's implementation of Hashtable
        score[PlayerKillScore] = newScore;

        player.SetCustomProperties(score);  // this locally sets the score and will sync it in-game asap.
    }

    public static void AddDeath(Player player, int scoreToAddToCurrent)
    {
        int current = GetDeaths(player);
        if (current == -1)
        {
            current = 0;
        }
        current = current + scoreToAddToCurrent;

        Hashtable score = new Hashtable();  // using PUN's implementation of Hashtable
        score[PlayerDeathScore] = current;

        player.SetCustomProperties(score);  // this locally sets the score and will sync it in-game asap.
    }

    public static int GetDeaths(Player player)
    {
        object score;
        if (player.CustomProperties.TryGetValue(PlayerDeathScore, out score))
        {
            return (int)score;
        }

        return 0;
    }

    public static void SetDeaths(Player player, int newScore)
    {
        Hashtable score = new Hashtable();  // using PUN's implementation of Hashtable
        score[PlayerDeathScore] = newScore;

        player.SetCustomProperties(score);  // this locally sets the score and will sync it in-game asap.
    }
}
