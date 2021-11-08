using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float bulletDamage;

    public void setBulletDamage(float val)
    {
        bulletDamage = val;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }
}
