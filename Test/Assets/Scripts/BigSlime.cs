using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSlime : MonoBehaviour
{
    public GameObject player;
    public GameObject small_slime;
    public Rigidbody2D slime_rb;
    public GameObject game_control;
    public float speed;
    public float direction = 1;
    public bool damage = true;
    public Animator slime_anim;
    public Animator player_anim;
    public float sight_x=5;
    public float sight_y=2;
    public AudioSource sfx;
    public AudioClip hurt;
    public AudioClip suck;
    public bool slime_spawned;

    // Start is called before the first frame update
    void Start()
    {
        slime_rb = GetComponent<Rigidbody2D>();
        game_control = GameObject.FindGameObjectWithTag("GameController");
        player = GameObject.FindGameObjectWithTag("Player");
        slime_anim = GetComponent<Animator>();
        player_anim = player.GetComponent<Animator>();
        sfx = game_control.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (this.transform.position.x < player.transform.position.x)
        {   
            direction = 1;
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x)>0.04 )
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }else{
                slime_anim.SetBool("Walk", false);
            }
        }else if (this.transform.position.x > player.transform.position.x)
            {   
            direction = -1;
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x)>0.04 )
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (Mathf.Abs(this.transform.position.x) - Mathf.Abs(player.transform.position.x) < sight_x &&  Mathf.Abs(this.transform.position.y) - Mathf.Abs(player.transform.position.y) < sight_y)
        {   
            speed = 2;
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x)>0.04 )
            {
                slime_anim.SetBool("Walk", true);
            }
        }else{
            speed = 0;
            slime_anim.SetBool("Walk", false);
        }

        if(speed!=0){
            slime_rb.velocity = new Vector2(direction*speed, slime_rb.velocity.y);
        }
    }
 
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player"){
            Rigidbody2D char_rb = collider.gameObject.GetComponent<Rigidbody2D>();
            Vector2 thrust = new Vector2(speed*direction, 1);
            collider.gameObject.GetComponent<Char_Move>().enabled = false;
            player.GetComponent<Vacuum>().enabled = false;
            if(damage == true){
                sfx.PlayOneShot(hurt,1);
                game_control.GetComponent<Game_Controller>().health_amt = game_control.GetComponent<Game_Controller>().health_amt -25;
            }
            StartCoroutine(knockback());
            char_rb.AddForce(thrust,ForceMode2D.Impulse);
            speed = 0;
            
            //char_rb.AddForce(thrust);
            //Should temporarily disable char_move to fix this 
        }
    }

    // void OnTriggerExit2D(Collider2D collider)
    // {
    //     if (collider.gameObject.tag == "Player"){
    //         speed = 0;
    //         slime_anim.SetBool("Walk", false);
    //     }
    // }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Suck"){
            sfx.PlayOneShot(suck,1);
            player.GetComponent<Char_Move>().enabled = true;
            player.GetComponent<Vacuum>().enabled = true;
            player_anim.SetBool("Damage",false);
            if (!slime_spawned){
                Instantiate(small_slime,this.gameObject.transform.position,this.gameObject.transform.rotation);
                slime_spawned = true;
            }
            Destroy(this.gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Suck"){
            sfx.PlayOneShot(suck,1);
            player.GetComponent<Char_Move>().enabled = true;
            player.GetComponent<Vacuum>().enabled = true;
            player_anim.SetBool("Damage",false);
            if (!slime_spawned){
                Instantiate(small_slime,this.gameObject.transform.position,this.gameObject.transform.rotation);
                slime_spawned = true;
            }
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
