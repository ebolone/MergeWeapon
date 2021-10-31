using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
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
        public void CreateRoom()
        {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        MenuManager.Instance.OpenMenu("loading");
        }
    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;



    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "room creation failed" + message;
        MenuManager.Instance.OpenMenu("error");

       
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");

    }
    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("principale");
    }
}
