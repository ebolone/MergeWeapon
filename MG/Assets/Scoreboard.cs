using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Scoreboard : MonoBehaviourPunCallbacks
{

    [SerializeField] Transform container;
    [SerializeField] GameObject scoreboardItemPrefab;

    Dictionary<Player, ScoreboardItem> scoreboardItems = new Dictionary<Player, ScoreboardItem>();

    private void Start()
    {

    }


    public void AddPlayer(Player player)
    {
        AddScoreboardItem(player);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddScoreboardItem(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RemoveScoreboardItem(otherPlayer);
    }

    void AddScoreboardItem(Player player)
    {
        ScoreboardItem item = Instantiate(scoreboardItemPrefab, container).GetComponent<ScoreboardItem>();
        item.Initialize(player);
        scoreboardItems[player] = item;
    }

    void RemoveScoreboardItem(Player player)
    {
        Destroy(scoreboardItems[player].gameObject);
        scoreboardItems.Remove(player);
    }

    private void Update()
    {
       //foreach (Player player in PhotonNetwork.PlayerList)
       //{
       //    scoreboardItems[player].UpdateScore(player);
       //}
    }
}
