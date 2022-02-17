using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;

public class WeaponChoosing : MonoBehaviourPunCallbacks
{
    public static int selectedArma1;
    public static int selectedArma2;
    [SerializeField] PhotonView player_PV;
    // Start is called before the first frame update
    void Start()
    {
        if (player_PV.IsMine)
        {
            SelectWeapon(selectedArma1, selectedArma2);
            Hashtable hash1 = new Hashtable();
            hash1.Add("item index1", selectedArma1);
            hash1.Add("item index2", selectedArma2);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash1);
        }
         
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SelectWeapon(int index1, int index2)
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == index1 || i == index2)
                weapon.gameObject.SetActive(true);
            i++;
        }
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (!player_PV.IsMine && targetPlayer == player_PV.Owner)
            SelectWeapon((int)changedProps["item index1"], (int)changedProps["item index2"]);
    }
}
