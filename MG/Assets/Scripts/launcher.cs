using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
 
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("connettendosi al master..");
            PhotonNetwork.ConnectUsingSettings();

        }
        public override void OnConnectedToMaster()
        {
            Debug.Log("connessi al master");
            PhotonNetwork.JoinLobby();

        }
        public override void OnJoinedLobby()
        {
            MenuManager.Instance.OpenMenu("principale");

            Debug.Log("entrati nella lobby");
        }

        // Update is called once per frame
    }
