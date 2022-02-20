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
    bool isDead = false;
    float spawnDelay = 3f;
    float timeNeeded;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        netManager = this;
        timeNeeded = spawnDelay;
        PlayerIsDead();

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
            }
        }

    }
    void RespawnPlayer()
    {
        Vector3 zero =new Vector3(0f,0f,0f);
        do{position = new Vector3(Random.Range(-58.0f, 58.0f), 0, Random.Range(-58.0f, 58.0f));
        } while (Vector3.Distance(position, zero)<55.0f);
        PhotonNetwork.Instantiate(playerPreFabs.name, position, Quaternion.identity);

    }
    // chiamata da playerdamage
    public void PlayerIsDead()
    {
        isDead = true;
        RespawnText.gameObject.SetActive(true);

    }
}

