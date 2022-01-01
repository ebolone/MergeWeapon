using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    string victim;
    public Text killText;
    string killMessage;
    Animator anim;
    float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        timePassed = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("NewDead"))
        {
            timePassed += Time.deltaTime;
            if(timePassed > 2f)
            {
                anim.SetBool("NewDead", false);
                anim.SetBool("Reverse", true);
                timePassed = 0f;
            }
        }
        
    }
    public void setVictimeName(string vname, string kname)
    {
        killMessage = kname + "has killed" + vname;
        killText.text = killMessage;
        if (anim.GetBool("NewDead"))
        {
            timePassed = 0f;
        }
        else
        {
            anim.SetBool("Reverse", false);
            anim.SetBool("NewDead", true);
        }

    }
}
