using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum_Collect : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject vac_bar;
    public Vacuum vac_script;
    public int textCount = -1;
    public AudioSource sfx;
    public AudioClip collect;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject game_control = GameObject.FindGameObjectWithTag("GameController");
        sfx = game_control.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && textCount == 0){
            text1.SetActive(false);
            text2.SetActive(true);
            textCount++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && textCount == 1){
            player.GetComponent<Char_Move>().enabled = true;
            text2.SetActive(false);
            textCount++;
            Time.timeScale = 1;
            Destroy(this.gameObject);
        }
            
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            sfx.PlayOneShot(collect,1);
            vac_script.enabled = true;
            vac_bar.SetActive(true);
            text1.SetActive(true);
            textCount = 0;
            Time.timeScale = 0;
            player.GetComponent<Char_Move>().enabled = false;
            
        }
    }
}
