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
        if (!playerPreFabs.GetPhotonView().IsMine)
            return;
        playerPreFabs.GetComponent<CharacterController>().enabled = true;
        playerPreFabs.transform.Find("Camera").gameObject.GetComponent<CameraController>().enabled = true;
        playerPreFabs.transform.Find("Camera").gameObject.GetComponent<CameraController>().setTarget(playerPreFabs.transform);
        playerPreFabs.transform.Find("Camera").gameObject.SetActive(true);

    }
}
