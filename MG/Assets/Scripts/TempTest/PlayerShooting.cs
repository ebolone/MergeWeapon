using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviourPun
{

    public Transform firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public GameObject effectToSpawn;
    float fireRate = 0.3f;
    float timePassed = 0f;

    // Use this for initialization
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (photonView.IsMine && Input.GetMouseButton(0) && timePassed >= fireRate)
        {
            Shooting();
        }
    }

    void Shooting()
    {
        //Istanzia un proiettile 
        photonView.RPC("InstantiateBullet", RpcTarget.All, null);
        timePassed = 0f;
    }


    [PunRPC]
    void InstantiateBullet()
    {
        GameObject vfx;
        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, firePoint.rotation);
            vfx.transform.localRotation = this.transform.rotation;
        }
    }
}
