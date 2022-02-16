using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class KillCounter2 : MonoBehaviourPun
{
    public int totalKills = 0;
    public int totalDeaths = 0;

    private void Start()
    {
        Hashtable PlayerCustomProps = new Hashtable();
        PlayerCustomProps["Kills"] = 0;
        PlayerCustomProps["Deaths"] = 0;
        PhotonNetwork.LocalPlayer.SetCustomProperties(PlayerCustomProps);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && photonView.IsMine)
        {
            totalKills++;
            AssignKillToPlayer();
        }
        if (Input.GetKeyDown(KeyCode.P) && photonView.IsMine)
        {
            totalDeaths++;
            AssignDeathToPlayer();
        }
    }

    public void AssignKillToPlayer()
    {
        Hashtable PlayerCustomProps = new Hashtable();
        PlayerCustomProps["Kills"] = totalKills;
        PhotonNetwork.LocalPlayer.SetCustomProperties(PlayerCustomProps);
        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["Kills"]);
    }

    public void AssignDeathToPlayer()
    {
        Hashtable PlayerCustomProps = new Hashtable();
        PlayerCustomProps["Deaths"] = totalDeaths;
        PhotonNetwork.LocalPlayer.SetCustomProperties(PlayerCustomProps);
        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["Deaths"]);
    }

}
