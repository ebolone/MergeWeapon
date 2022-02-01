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
    public GameObject destroyEffect;
    public Animator animator;


    private void Start()
    {
        animator.SetBool("isDead", false);
        currentHp = maxHp;
        setMaxHealth(maxHp);
    }

    private void Update()
    {
        if (currentHp <= 0 && photonView.IsMine)
        {
            animator.SetBool("isDead", true);
            NetworkManager.netManager.PlayerIsDead();
            PhotonNetwork.Destroy(gameObject);
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
        setHealth(currentHp);
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
