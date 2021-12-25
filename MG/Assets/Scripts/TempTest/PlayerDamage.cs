using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviourPun
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public float maxHp;
    private float currentHp;
    public HealthBar healthBar;
    public GameObject destroyEffect;


    private void Start()
    {
        if (photonView.IsMine)
        {
            currentHp = maxHp;
            healthBar.setMaxHealth(maxHp);
        }
    }

    public void GetDamage(float amountOfDamage)
    {
        photonView.RPC("ApplyDamage", RpcTarget.AllViaServer, amountOfDamage);
    }

    [PunRPC]
    public void ApplyDamage(float amountOfDamage)
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

    public void setMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        fill.color = gradient.Evaluate(1f);
    }

    public void setHealth(float health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
