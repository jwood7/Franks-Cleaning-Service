using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Detector : MonoBehaviour
{
    public Animator char_anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        //Debug.Log("Landed");
        char_anim.SetBool("Jump", false);
        char_anim.SetBool("StartJump", false);
    }

    void OnTriggerExit2D(Collider2D collision){
        //Debug.Log("Jumped");
        char_anim.SetBool("Jump", true);
    }
}
