using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviourPun
{
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public List<GameObject> vfx = new List<GameObject>();
    public GameObject effectToSpawn;

    float fireRate = 0.3f;
    float timePassed = 0f;

    public PlayerInput playerInput;
    private CharacterController controller;
    bool shooting;
    bool look;

    // Use this for initialization
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        shooting = playerInput.actions["Shoot"].triggered; 
        look = playerInput.actions["Look"].triggered;

        if(look){
            animator.SetBool("isShooting", true);
        }
        else{
            animator.SetBool("isShooting", false);
        }

        timePassed += Time.deltaTime;
        if (photonView.IsMine && shooting && timePassed >= fireRate)
        {    
            Shooting();   
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
