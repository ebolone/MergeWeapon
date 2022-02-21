using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ProjectileMove : MonoBehaviourPun
{
    public float speed;
    public float fireRate;
    public int  numeroColpi = 1;
    public float tempoTraColpiConsecutivi = 0;
    public GameObject hitPrefab;
    public float maxSpread = 0;
    public float timeToDestroy = 0.5f;
    public float bulletDamage;
    float tempoAttuale = 0;

    public Player Owner { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
       

        Vector3 dir = transform.forward + new Vector3(Random.Range(-maxSpread, maxSpread), 0, Random.Range(-maxSpread, maxSpread));
        this.GetComponent<Rigidbody>().AddForce(dir * speed);

    }

    // Update is called once per frame
    void Update()
    {
        if (timeToDestroy > tempoAttuale)
        {
            tempoAttuale += 0.01f;
        }
        else Destroy(gameObject);
  
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        if(hitPrefab != null)
        {
            var hitVFX = Instantiate(hitPrefab, pos, rot);
            Destroy(hitVFX, 1f);

        }
        if (collision.collider.tag == "Player" && PhotonNetwork.IsMasterClient)
        {
            collision.collider.gameObject.GetComponent<PlayerDamage>().GetDamage(bulletDamage, Owner);
        }

        Destroy(gameObject);
    }
    public void InitializeBullet(Player owner)
    {
        this.Owner = owner;
    }
}
