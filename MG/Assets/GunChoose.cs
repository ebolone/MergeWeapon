using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunChoose : MonoBehaviour
{
    public bool a1 = true;
    public bool a2 = true;
    [SerializeField] Buttons[] arma_posizione_primaria;
    [SerializeField] Buttons[] arma_posizione_secondaria;
    [SerializeField] GameObject arma;
    public void Awake()
    {
        for(int i = 0; i < arma_posizione_primaria.Length; i++)
        {
            arma_posizione_primaria[i].SetValore(i);
            Debug.Log("set" + i);
        }
        for (int i = 0; i < arma_posizione_secondaria.Length; i++)
        {
            arma_posizione_secondaria[i].SetValore(i);
            Debug.Log("set" + i);
        }
    }
    public void setArmaPrincipale(Buttons arma_scelta)
    {
        int valore = arma_scelta.GetValore();
        for(int i = 0; i < arma_posizione_primaria.Length; i++)
        {
            if (i == valore)
            {
                WeaponChoosing.selectedArma1 = valore;
                int n = 0;
                foreach (Transform weapon in arma.transform.GetChild(0))
                {
                    if (n == valore)
                        weapon.gameObject.SetActive(true);
                    else weapon.gameObject.SetActive(false);
                    n++;
                }
            }
        }
        
    }
    public void setArmaSecondaria(Buttons arma_scelta)
    {
        int valore = arma_scelta.GetValore();
        Debug.Log("valore = " + valore);
        for (int i = 0; i < arma_posizione_secondaria.Length; i++)
        {
            if (i == valore)
            {
                WeaponChoosing.selectedArma2 = valore;
                int n = 0;
                foreach (Transform weapon in arma.transform.GetChild(1))
                {
                    if (n == valore)
                        weapon.gameObject.SetActive(true);
                    else weapon.gameObject.SetActive(false);
                    n++;
                }
            }
        }

    }
    public void setArmaAttivata()
    {
        arma.SetActive(true);
    }
    public void setArmaDisattivata()
    {
        arma.SetActive(false);
    }
}
