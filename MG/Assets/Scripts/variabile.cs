using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class variabile : MonoBehaviour
{
    public GameObject player;
    public float distance;
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
        distance=Vector2.Distance(player.transform.position, GameObject.FindWithTag("Enemy").transform.position);
        while(distance<5 && rend.enabled==false){
                rend.enabled=true;
        }
    }
}
