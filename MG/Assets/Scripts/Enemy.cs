using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float maxHp;
    private float currentHp;
    public HealthBar healthBar;
    public GameObject destroyEffect;


    private void Start()
    {
        currentHp = maxHp;
        healthBar.setMaxHealth(maxHp);
    }

    public void TakeDamage(float amountOfDamage)
    {
        currentHp -= amountOfDamage;
        healthBar.setHealth(currentHp);
        if (currentHp <= 0)
            Die();
    }

    public void Die()
    {
        GameObject destroyAnimation = (GameObject)Instantiate(destroyEffect, transform.position, transform.rotation);
        Destroy(destroyAnimation, 4f);
        Destroy(gameObject);
    }
}
