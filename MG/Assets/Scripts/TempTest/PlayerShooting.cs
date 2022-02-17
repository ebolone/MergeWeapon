using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviourPun
{
    public Animator animator;
    public Transform firePoint;
    public List<GameObject> vfx1 = new List<GameObject>();
    public List<GameObject> vfx2 = new List<GameObject>();
    private GameObject effectToSpawnPrimario;
    private GameObject effectToSpawnSecondario;

    float timeToFire = 0f;
    float timeToFire2 = 0f;

    private PlayerInput playerInput;
    bool shooting;
    bool shooting2;
    bool look;

    // Use this for initialization
    void Start()
    {
        playerInput = gameObject.GetComponent<PlayerInput>();
        effectToSpawnPrimario = vfx1[WeaponChoosing.selectedArma1];
        effectToSpawnSecondario = vfx2[WeaponChoosing.selectedArma2];
    }

    // Update is called once per frame
    void Update()
    {
        shooting = playerInput.actions["Shoot"].triggered;
        shooting2 = playerInput.actions["Shoot2"].triggered;
        look = playerInput.actions["Look"].triggered;

        if(look){
            animator.SetBool("isShooting", true);
        }
        else{
            animator.SetBool("isShooting", false);
        }

        if (photonView.IsMine && shooting && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawnPrimario.GetComponent<ProjectileMove>().fireRate;
            for (int i = 0; i < effectToSpawnPrimario.GetComponent<ProjectileMove>().numeroColpi; i++)
            {


                Shooting1();

            }
        }
        if (photonView.IsMine && shooting2 && Time.time >= timeToFire2)
        {
            timeToFire2 = Time.time + 1 / effectToSpawnSecondario.GetComponent<ProjectileMove>().fireRate;
            for (int i = 0; i < effectToSpawnSecondario.GetComponent<ProjectileMove>().numeroColpi; i++)
            {

                Shooting2();

            }
        }
    }

    void Shooting1()
    {
        //Istanzia un proiettile 
        photonView.RPC("InstantiateBullet", RpcTarget.All, null);
    }
    void Shooting2()
    {
        photonView.RPC("InstatiateBullet2", RpcTarget.All);
    }


    [PunRPC]
    void InstantiateBullet()
    {
        GameObject vfx;
        vfx = Instantiate(effectToSpawnPrimario, firePoint.transform.position, firePoint.rotation);
        vfx.transform.localRotation = this.transform.rotation;
    }
    [PunRPC]
    void InstatiateBullet2()
    {
        GameObject vfx;
        vfx = Instantiate(effectToSpawnSecondario, firePoint.transform.position, firePoint.rotation);
        vfx.transform.localRotation = this.transform.rotation;
    }
}
