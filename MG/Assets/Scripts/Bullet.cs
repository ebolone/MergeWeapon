using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float bulletDamage;
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
        rb.AddForce(transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
