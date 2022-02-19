using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public TMP_Text InfoText;
    private Player winner;
    public GameObject scoreboard;
    public GameObject canvas;
    public bool isOver = false;

    public int killsToWin;

    private void LateUpdate()
    {
        if (isOver != true)
            checkForWinCondition();
    }

    public void checkForWinCondition()
    {
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            if (Scores.GetKills(p) >= killsToWin)
                this.winner = p;
        }
        if (this.winner != null)
        {
            isOver = true;
            if (PhotonNetwork.IsMasterClient)
            {
                StopAllCoroutines();
            }
            canvas.SetActive(true);
            Player[] players = sortPlayers(PhotonNetwork.PlayerList);
            foreach (Player player in players)
            {
            scoreboard.SendMessage("AddPlayer", player);
            }
            string winner = this.winner.NickName;
            int score = Scores.GetKills(this.winner);

            StartCoroutine(EndOfGame(winner, score));
        }
    }

    private IEnumerator EndOfGame(string winner, int score)
    {
        float timer = 5.0f;

        while (timer > 0.0f)
        {
            InfoText.text = string.Format("Player {0} won with {1} kills.\n\nReturning to login screen in {2} seconds.", winner, score, timer.ToString("n2"));

            yield return new WaitForEndOfFrame();

            timer -= Time.deltaTime;
        }

        PhotonNetwork.LeaveRoom();
    }

    Player[] sortPlayers(Player[] list)
    {
        int i,j,flag;
        Player val;

        for (i = 1; i < PhotonNetwork.PlayerList.Length; i++)
        {
            val = list[i];
            flag = 0;
            for (j = i - 1; j >= 0 && flag != 1;)
            {
                if (Scores.GetKills(val) > Scores.GetKills(list[j]))
                {
                    list[j + 1] = list[j];
                    j--;
                    list[j + 1] = val;
                }
                else flag = 1;
            }
        }
         return list;
        }
    }