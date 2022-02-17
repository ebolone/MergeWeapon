using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviourPun
{
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;

    float fireRate = 0.3f;
    float timePassed = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (photonView.IsMine && Input.GetKey(KeyCode.K) && timePassed >= fireRate)
        {
            Shooting();
        }
        else
            animator.SetBool("isShooting", false);
    }

    void Shooting()
    {
        animator.SetBool("isShooting", true);
        //Istanzia un proiettile 
        bulletPrefab.GetComponent<Bullet>().viewID = PhotonNetwork.LocalPlayer.UserId;
        photonView.RPC("InstantiateBullet", RpcTarget.All, null);
        timePassed = 0f;
    }


    [PunRPC]
    void InstantiateBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
