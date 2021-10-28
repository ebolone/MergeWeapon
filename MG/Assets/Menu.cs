using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string menuName;
    void open()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void close()
    {
        gameObject.SetActive(false);
    }
}
