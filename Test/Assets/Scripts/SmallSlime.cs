using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSlime : MonoBehaviour
{
    public GameObject patrol_1;
    public GameObject patrol_2;
    public GameObject game_control;
    public GameObject player;
    public Rigidbody2D slime_rb;
    public float speed;
    public bool damage = true;
    public Animator player_anim;
    public AudioSource sfx;
    public AudioClip hurt;
    public AudioClip suck;

    // Start is called before the first frame update
    void Start()
    {
        slime_rb = GetComponent<Rigidbody2D>();
        game_control = GameObject.FindGameObjectWithTag("GameController");
        player = GameObject.FindGameObjectWithTag("Player");
        player_anim = player.GetComponent<Animator>();
        sfx = game_control.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < patrol_1.transform.position.x)
        {   
            speed = 1.5f;
            GetComponent<SpriteRenderer>().flipX = true;
        }else if (this.transform.position.x > patrol_2.transform.position.x)
        {   
            speed = -1.5f;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        slime_rb.velocity = new Vector2(speed, slime_rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player"){
            
            //game_control = GameObject.FindGameObjectWithTag("GameController");
            if(damage == true){
                game_control.GetComponent<Game_Controller>().health_amt = game_control.GetComponent<Game_Controller>().health_amt -25;
                sfx.PlayOneShot(hurt,1);
            }
            collider.gameObject.GetComponent<Char_Move>().enabled = false;
            player.GetComponent<Vacuum>().enabled = false;
            Vector2 thrust = new Vector2(speed*0.75f, 1);
            StartCoroutine(knockback());
            player.gameObject.GetComponent<Rigidbody2D>().AddForce(thrust,ForceMode2D.Impulse);
        }
        else if (collider.gameObject.tag == "Slime"){
        }
        else 
        {
            //speed = speed*-1;
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Suck"){
            player.GetComponent<Char_Move>().enabled = true;
            player.GetComponent<Vacuum>().enabled = true;
            player_anim.SetBool("Damage",false);
            sfx.PlayOneShot(suck,1);
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Suck"){
            player.GetComponent<Char_Move>().enabled = true;
            player.GetComponent<Vacuum>().enabled = true;
            player_anim.SetBool("Damage",false);
            sfx.PlayOneShot(suck,1);
            Destroy(this.gameObject);
        }
    }

    public IEnumerator knockback()
    {
        damage = false;
        player_anim.SetBool("Damage",true);
        yield return new WaitForSeconds(1.0f);
        player.GetComponent<Char_Move>().enabled = true;
        player.GetComponent<Vacuum>().enabled = true;
        damage = true;
        player_anim.SetBool("Damage",false);
        
    }
}
