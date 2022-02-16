using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class KillCounter : MonoBehaviourPun
{
    int killCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (photonView.IsMine)
                AssignKillToPlayer(PhotonNetwork.LocalPlayer);
        }
        ///
        int KillCount = (int)PhotonNetwork.LocalPlayer.CustomProperties["Kills"];
        killCount++;
        Hashtable hash = new Hashtable();
        hash.Add("Kills", killCount);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        ///
    }

    public void AssignKillToPlayer(Player player)
    {
        ScoreExtensions.AddScore(player, 1);
        Debug.Log(ScoreExtensions.GetScore(player));
    }
}
