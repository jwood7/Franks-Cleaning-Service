using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash_Collect : MonoBehaviour
{
    public GameObject game_control;
    public AudioSource collect_sfx;
    // Start is called before the first frame update
    void Start()
    {
        game_control = GameObject.FindGameObjectWithTag("GameController");
        collect_sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collect_sfx.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            game_control.GetComponent<Game_Controller>().health_amt++;
            //Destroy(this.gameObject);
        }
    }
}
