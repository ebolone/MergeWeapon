using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
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

    int numMorti = 0;


    private void Start()
    {
        animator.ResetTrigger("isDead");
        currentHp = maxHp;
        setMaxHealth(maxHp);
    }

    private void Update()
    {
        if (currentHp <= 0 && photonView.IsMine)
        {
            animator.SetTrigger("isDead");
            NetworkManager.netManager.PlayerIsDead();
            Invoke("DestroyChar", 1.2f);
        }
        numMorti = Scores.GetDeaths(photonView.Owner);
    }

    public void GetDamage(float amountOfDamage, Player shooter)
    {
        photonView.RPC("ApplyDamage", RpcTarget.AllViaServer, amountOfDamage,shooter);
    }

    [PunRPC]
    public void ApplyDamage(float amountOfDamage, Player shooter)
    {
        currentHp -= amountOfDamage;
        setHealth(currentHp);
        if (currentHp <= 0)
        {
            Scores.AddKill(shooter,1);
            Scores.AddDeath(photonView.Owner, 1);
            Debug.Log(shooter.NickName + " ha effettuato un uccisione. Ora ha un totale di " + Scores.GetKills(shooter) + " uccisioni");
            Debug.Log(photonView.Owner.NickName + " � stato ucciso, ora ha un totale di " + Scores.GetDeaths(photonView.Owner) + " morti");
        }
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

    public void DestroyChar()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
