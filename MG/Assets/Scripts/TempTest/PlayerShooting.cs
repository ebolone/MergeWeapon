using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviourPun
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    float fireRate = 0.3f;
    float timePassed = 0f;
    private PlayerInput playerInput;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        //timePassed += Time.deltaTime;
        //photonView.IsMine && Input.GetMouseButton(0) && timePassed >= fireRate)
        
            StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        yield return null;
        //Istanzia un proiettile 
        bool shot = playerInput.actions["Shoot"].triggered;
        if (shot)
        {
            photonView.RPC("InstantiateBullet", RpcTarget.All, null);
            timePassed = 0f;
        }
    }


    [PunRPC]
    void InstantiateBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
