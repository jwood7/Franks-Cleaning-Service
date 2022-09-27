using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public Rigidbody2D char_rb;
    public float speed;
    public GameObject Upper_Suck;
    public GameObject Under_Suck;
    public GameObject Right_Suck;
    public Animator char_anim;
    public HealthBar healthBar;
    public float charge = 100f;
    public float oChargeMultiplier;
    public float chargeMultiplier;
    public bool canRecharge = true;
    public GameObject instructions;
    public AudioSource sfx;
    public AudioSource sfx2;
    public AudioClip recharge;
    public Coroutine lastCoroutine;
    public bool empty;
    //public AudioClip vac_sfx;
    //public AudioClip vac_sfx;
    // Start is called before the first frame update
    void Start()
    {
        char_rb = GetComponent<Rigidbody2D>();
        char_anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(100f);
        chargeMultiplier = oChargeMultiplier;
        sfx = GetComponent<AudioSource>();
        GameObject game_control = GameObject.FindGameObjectWithTag("GameController");
        sfx2 = game_control.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float x_in = Input.GetAxisRaw("Horizontal");
        float y_in = Input.GetAxisRaw("Vertical");
        if((Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.J))&& charge > 0f){
            if (lastCoroutine != null){
                StopCoroutine(lastCoroutine);
                canRecharge = false;
            }
            if (!sfx.isPlaying){
            //    sfx.clip = vac_sfx;
            //    sfx.loop = true;
                sfx.Play();
            }
            instructions.SetActive(false);
            canRecharge = false;
            char_anim.SetBool("Vac_Active", true);
            //Debug.Log("F down");
            //char_rb.velocity = new Vector2(char_rb.velocity.x+x_in*speed, char_rb.velocity.y+y_in*speed);
            //StartCoroutine(vac_timer());
            charge = charge - chargeMultiplier*Time.deltaTime;
            healthBar.SetHealth(charge);
            
            if (y_in < 0){
                y_in = y_in * 5;
                //Set lower trigger active
                Under_Suck.SetActive(true);
                Upper_Suck.SetActive(false);
                Right_Suck.SetActive(false);
                char_anim.SetBool("VacUp", false);
                char_anim.SetBool("VacDown", true);
            }else{
                //set upper trigger active
                Under_Suck.SetActive(false);
                Upper_Suck.SetActive(true);
                Right_Suck.SetActive(false);
                char_anim.SetBool("VacUp", true);
                char_anim.SetBool("VacDown", false);
            }
            if (x_in != 0){
                //Set left trigger active
                Right_Suck.SetActive(true);
                //Under_Suck.SetActive(false);
                Upper_Suck.SetActive(false);
                char_anim.SetBool("VacFront", true);
            }
            if (y_in == 0){
                Under_Suck.SetActive(false);
                Upper_Suck.SetActive(false);
                char_anim.SetBool("VacUp", false);
                char_anim.SetBool("VacDown", false);
            }
            if (x_in == 0){
                //Left_Suck.SetActive(false);
                Right_Suck.SetActive(false);
                char_anim.SetBool("VacFront", false);
            }
            //Implement diagonal triggers eventually.
            if (char_rb.velocity.y>1.5 || char_rb.velocity.y<-5 ){
                y_in = 0;
            }
            Vector2 thrust = new Vector2(x_in*speed, y_in*speed);
            char_rb.AddForce(thrust);
            
        }else{
            //Left_Suck.SetActive(false);
            sfx.Stop();
            Right_Suck.SetActive(false);
            Under_Suck.SetActive(false);
            Upper_Suck.SetActive(false);
            char_anim.SetBool("VacFront", false);
            char_anim.SetBool("VacUp", false);
            char_anim.SetBool("VacDown", false);
            char_anim.SetBool("Vac_Active", false);
            if (charge < 100 && canRecharge){
                charge = charge + 5.0f*chargeMultiplier*Time.deltaTime;
                healthBar.SetHealth(charge);
                empty = false;

            }
        }

        if (charge <= 0 && !empty){
            if (lastCoroutine != null){
                StopCoroutine(lastCoroutine);
                canRecharge = false;
            }
            lastCoroutine = StartCoroutine(vac_timer());
            empty = true;
        }

        if(Input.GetKeyUp(KeyCode.F)||Input.GetKeyUp(KeyCode.J)){
            if (lastCoroutine != null){
                StopCoroutine(lastCoroutine);
                canRecharge = false;
            }
            //Left_Suck.SetActive(false);
            sfx.Stop();
            Right_Suck.SetActive(false);
            Under_Suck.SetActive(false);
            Upper_Suck.SetActive(false);
            char_anim.SetBool("Vac_Active", false);
            canRecharge = false;
            lastCoroutine = StartCoroutine(vac_timer());
        }

    }

    public IEnumerator vac_timer()
    {
        yield return new WaitForSeconds(1.5f);
        canRecharge = true;
        sfx2.PlayOneShot(recharge,0.2f);
        
    }
}
