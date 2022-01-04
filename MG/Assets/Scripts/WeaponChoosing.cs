using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChoosing : MonoBehaviour
{
    public static int selectedArma1;
    public static int selectedArma2;
    // Start is called before the first frame update
    void Start()
    {
        selectWeapon();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void selectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedArma1 || i == selectedArma2)
                weapon.gameObject.SetActive(true);
            i++;
        }
    }
}
