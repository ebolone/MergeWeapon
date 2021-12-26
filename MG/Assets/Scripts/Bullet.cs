using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviourPun
{

    public float bulletDamage;
    public float bulletSpeed;
    private Rigidbody rb;


    void Start() 
    { 
     rb = gameObject.GetComponent<Rigidbody>();
    }

    public void setBulletDamage(float val)
    {
        bulletDamage = val;
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * bulletSpeed;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player" && PhotonNetwork.IsMasterClient)
        {
            col.collider.gameObject.GetComponent<PlayerDamage>().GetDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
}
