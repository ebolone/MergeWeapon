using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviourPun
{
    public Player owner { get; private set; }
    public float bulletDamage;
    public float bulletSpeed;
    private Rigidbody rb;
    public float timeToDestroy;

    private void Awake()
    {
        
    }

    void Start() 
    {
        Destroy(gameObject, timeToDestroy);
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

    public void InitializeBullet(Player owner)
    {
        this.owner = owner;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player" && PhotonNetwork.IsMasterClient)
        {
            col.collider.gameObject.GetComponent<PlayerDamage>().GetDamage(bulletDamage,owner);
        }
        Destroy(gameObject);
    }

    public void setShooter(Player shooter)
    {
        this.owner = shooter;
    }
}
