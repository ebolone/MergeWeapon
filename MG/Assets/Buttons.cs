using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public bool scelto;
    public int valore;
    public void ArmaScelta()
    {
        scelto = true;
    }
    public void ArmaTolta()
    {
        scelto = false;
    }
    public void SetValore(int indice)
    {
        valore = indice;
    }
    public int GetValore()
    {
        return valore;
    }
    
}
