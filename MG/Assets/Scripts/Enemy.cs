using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float hp;
    public GameObject destroyEffect;

    public void TakeDamage(float amountOfDamage)
    {
        Debug.Log("HIT");
        hp -= amountOfDamage;
        if (hp <= 0)
            Die();
    }

    public void Die()
    {
        GameObject destroyAnimation = (GameObject)Instantiate(destroyEffect, transform.position, transform.rotation);
        Destroy(destroyAnimation, 4f);
        Destroy(gameObject);
    }
}
