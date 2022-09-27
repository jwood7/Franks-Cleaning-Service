using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_Script : MonoBehaviour
{
    public float float_speed = 5;
    //public Rigidbody2D char_rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col){
        //Debug.Log("fan triggered");
        Rigidbody2D char_rb = col.gameObject.GetComponent<Rigidbody2D>();
        char_rb.velocity = new Vector2(char_rb.velocity.x, float_speed);
    
    }
}
