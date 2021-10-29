using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] Menu[] menus;
  
    public void Awake()
    {
        Instance = this;
    }
    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {

            if (menus[i].aperto)
            {
                CloseMenu(menus[i]);
            }
            

        }
        menu.Open();
    }
    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }
    public void OpenMenu(string nomeMenu)
    {
        for(int i = 0; i<menus.Length; i++)
        {
            if(menus[i].menuName == nomeMenu)
            {
                OpenMenu(menus[i]);
            }
            else if (menus[i].aperto)
            {
                CloseMenu(menus[i]);
            }


        }
    }
}
