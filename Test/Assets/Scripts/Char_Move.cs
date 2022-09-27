using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Move : MonoBehaviour
{
    public Rigidbody2D char_rb;
    public GameObject game_control;
    public float speed;
    public float jump_speed;
    public Animator char_anim;
    public AudioSource sfx;
    public AudioClip jump_sfx;

    // Start is called before the first frame update
    void Start()
    {
        char_rb = GetComponent<Rigidbody2D>();
        char_anim = GetComponent<Animator>();
        game_control = GameObject.FindGameObjectWithTag("GameController");
        sfx = game_control.GetComponent<AudioSource>();
        speed = 2.5f;
        //jump_speed = 7.0f;

    }

    // Update is called once per frame
    void Update()
    {
        main_char_move();
    }

    void main_char_move()
    {
        float x_pos = Input.GetAxisRaw("Horizontal");
        //Debug.Log(x_pos);
        char_rb.velocity = new Vector2(x_pos*speed, char_rb.velocity.y);
        if(x_pos<0)
        {
            this.transform.localScale = new Vector2(-1,1);
            char_anim.SetBool("canWalk", true);
        }else if (x_pos>0)
        {
            this.transform.localScale = new Vector2(1,1);
            char_anim.SetBool("canWalk", true);
        }else
        {
            char_anim.SetBool("canWalk", false);
        }

        if(Input.GetKeyDown(KeyCode.Space)&& (char_rb.velocity.y>-0.0001 && char_rb.velocity.y < 0.0001))
        {
            //char_anim.SetBool("StartJump", true);
            char_anim.SetBool("Jump", true);
            char_anim.SetBool("StartJump", false);
            char_rb.velocity = new Vector2(char_rb.velocity.x, jump_speed);
            sfx.clip = jump_sfx;
            sfx.loop = false;
            sfx.Play();
        }
        // if(Input.GetKeyUp(KeyCode.Space) && (char_rb.velocity.y>-0.0001 && char_rb.velocity.y < 0.0001))
        // {
        //     char_anim.SetBool("Jump", true);
        //     char_anim.SetBool("StartJump", false);
        //     char_rb.velocity = new Vector2(char_rb.velocity.x, jump_speed);
        //     jump_sfx.Play();
            
        // }
        // if(char_rb.velocity.y < -1)
        // {
        //     char_anim.SetBool("Jump", false);
        // }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            char_anim.SetBool("Crouch", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            char_anim.SetBool("Crouch", false);
        }
    }
}
