using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyCard_Get : MonoBehaviour
{
    //public Animator curtain_anim;
    public GameObject curtain;
    public WinState Win;
    public GameObject player;
    public GameObject keyCardUI;
    public AudioSource sfx;
    public AudioClip collect;
    public int collectCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject game_control = GameObject.FindGameObjectWithTag("GameController");
        sfx = game_control.GetComponent<AudioSource>();
        curtain = GameObject.FindGameObjectWithTag("Curtain");
        //keyCardUI = GameObject.FindGameObjectWithTag("KeyCardUI");
        //This fails :(
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && collectCount == 0)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            sfx.PlayOneShot(collect,1);
            keyCardUI.SetActive(true);
            Win.hasKey = true;
            collectCount++;
            //StartCoroutine(loadNext(1));
            //SceneManager.LoadScene(1);
            //Destroy(this.gameObject);
        }
    }

    public IEnumerator loadNext(int sceneIndex)
    {
        //curtain_anim.SetBool("curtain_go", true);
        curtain.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(sceneIndex);
    }
}
