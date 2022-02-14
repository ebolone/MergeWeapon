using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunChoose : MonoBehaviour
{
    public bool a1 = true;
    public bool a2 = true;
    [SerializeField] Buttons[] arma_posizione;
    public void Awake()
    {
        for(int i = 0; i < arma_posizione.Length; i++)
        {
            arma_posizione[i].SetValore(i);
            Debug.Log("set" + i);
        }
    }
    public void setArmaPrincipale(Buttons arma_scelta)
    {
        int valore = arma_scelta.GetValore();
        Debug.Log("valore = " + valore);
        for(int i = 0; i < arma_posizione.Length; i++)
        {
            if (i == valore)
            {
                WeaponChoosing.selectedArma1 = valore;
            }
        }
        
    }
    public void setArmaSecondaria(Buttons arma_scelta)
    {
        int valore = arma_scelta.GetValore();
        Debug.Log("valore = " + valore);
        for (int i = 0; i < arma_posizione.Length; i++)
        {
            if (i == valore)
            {
                WeaponChoosing.selectedArma2 = valore;
            }
        }

    }
    public void ResetGun1()
    {
        a1 = true;
    }
    public void ReserGun2()
    {
        a2 = true;
    }
}
