using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float hp;
    public GameObject particle;

    public void TakeDamage(float amountOfDamage)
    {
        Debug.Log("HIT");
        hp -= amountOfDamage;
        if (hp <= 0)
            Die();
    }

    public void Die()
    {
        GameObject deathAnimation = Instantiate(particle, gameObject.transform);
        Destroy(deathAnimation, 2f);
        Destroy(gameObject);
    }
}
