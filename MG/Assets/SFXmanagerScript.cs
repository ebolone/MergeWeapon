using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanagerScript : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Click;

    public static SFXmanagerScript SFXinstance;

    public void Awake()
    {
        if(SFXinstance != null && SFXinstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        SFXinstance = this;
        DontDestroyOnLoad(this);
        
    }


}
