using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string menuName;
    public bool aperto;
    public void Open()
    {
        aperto = true;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    public void Close()
    {
        aperto = false;
        gameObject.SetActive(false);
    }
}
