using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variabile : MonoBehaviour
{
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend=GetComponent<Renderer>();
        rend.enabled=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
