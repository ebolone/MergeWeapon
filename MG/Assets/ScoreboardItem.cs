using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class ScoreboardItem : MonoBehaviour
{

    public TMP_Text usernameText;
    public TMP_Text killsText;
    public TMP_Text deathsText;

    public void Initialize(Player player)
    {
        usernameText.text = player.NickName;
        killsText.SetText(Scores.GetKills(player).ToString());
        deathsText.SetText(Scores.GetDeaths(player).ToString());
    }

    public void UpdateScore(Player player)
    {
        killsText.SetText(Scores.GetKills(player).ToString());
        deathsText.SetText(Scores.GetDeaths(player).ToString());
    }
}
