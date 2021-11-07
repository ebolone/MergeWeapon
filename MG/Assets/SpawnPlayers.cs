using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPreFabs;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(playerPreFabs.name, Vector3.zero, Quaternion.identity);
        
    }
}
