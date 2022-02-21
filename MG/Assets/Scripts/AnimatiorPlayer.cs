using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatiorPlayer : MonoBehaviour
{
   [SerializeField] GameObject mainProjectile;
    public ParticleSystem mainPS;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mainProjectile.SetActive(true);
        }
        if (mainPS.IsAlive() == false)
            mainProjectile.SetActive(false);
    }
}
