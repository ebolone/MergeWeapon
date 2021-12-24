using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scomparsa : MonoBehaviour
{
    variabile invisible;
    
    // Start is called before the first frame update
    void Start()
    {
        invisible=GameObject.FindWithTag("Soldato").GetComponent<variabile>();
        invisible.rend.enabled=true;
    }

    void OnTriggerStay()
    {
        invisible.rend.enabled=false;
    }

    void OnTriggerExit()
    {
        invisible.rend.enabled=true;
    }
    
}
