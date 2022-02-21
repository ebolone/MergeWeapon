using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager netManager;
    public GameObject playerPreFabs;
    public Text RespawnText;
    public Text SpawnText;
    bool isDead = false;
    float spawnDelay = 3f;
    float timeNeeded;
    Vector3 position;
    List<Vector3> r = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
     
        netManager = this;
        timeNeeded = spawnDelay;
        PlayerIsDead();
        
        r.Add(new Vector3(16, 0, 25));
        r.Add(new Vector3(-15, 0, 10));
        r.Add(new Vector3(17, 0, -21));
        r.Add(new Vector3(-27, 0, -27));
        SpawnText.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            RespawnText.text = "Respawning..." + Mathf.Round(timeNeeded);
            timeNeeded -= Time.deltaTime;
            if (timeNeeded < 0.5f)
            {
                isDead = false;
                timeNeeded = spawnDelay;
                RespawnText.gameObject.SetActive(false);
                RespawnPlayer();
                SpawnText.gameObject.SetActive(false);
            }
        }

    }
    void RespawnPlayer()
    {
        int i = Random.Range(1, 4);
        position = r[i];
        PhotonNetwork.Instantiate(playerPreFabs.name, position, Quaternion.identity);


    }
    // chiamata da playerdamage
    public void PlayerIsDead()
    {
        isDead = true;
        RespawnText.gameObject.SetActive(true);

    }
}

