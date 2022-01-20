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
    private float timeToFire = 0;

    // Use this for initialization
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine && Input.GetMouseButton(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            for(int i = 0; i < effectToSpawn.GetComponent<ProjectileMove>().numeroColpi; i++)
            {

                Shooting();

            }
            
        }
    }

    void Shooting()
    {
        //Istanzia un proiettile 
        photonView.RPC("InstantiateBullet", RpcTarget.All, null);
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
