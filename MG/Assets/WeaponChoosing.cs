using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChoosing : MonoBehaviour
{
    public int selectedArma1 = 0;
    public int selectedArma2 = 0;
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
            else weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
