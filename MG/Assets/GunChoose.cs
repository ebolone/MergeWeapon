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
    public void setArma(Buttons arma_scelta)
    {
        int valore = arma_scelta.GetValore();
        Debug.Log("valore = " + valore);
        for(int i = 0; i < arma_posizione.Length; i++)
        {
            if (i == valore)
            {
                Debug.Log("entrato primo if");
                if (a1)
                {
                    WeaponChoosing.selectedArma1 = valore;
                    a1 = false;
                    Debug.Log("a1 test" + valore);
                }
                else if(a2)
                { 
                    WeaponChoosing.selectedArma2 = valore;
                    a2 = false;
                    Debug.Log("a2 test" + valore);
                }
                return;
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
