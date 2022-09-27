using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    public int Stage;
    public bool hasKey = false;
    public GameObject curtain;
    public GameObject requiresKey;
    public Animator door_anim;
    public int textCount = -1;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        door_anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(hasKey == true){
            door_anim.SetBool("hasKey", true);
        }else{
            if (Input.GetKeyDown(KeyCode.Space) && textCount == 0){
                textCount = 1;
                requiresKey.SetActive(false);
                Time.timeScale = 1;
                player.GetComponent<Char_Move>().enabled = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            if (hasKey == true)
            {
                door_anim.SetBool("open", true);
                StartCoroutine(loadNext(Stage));
            }else{
                requiresKey.SetActive(true);
                textCount = 0;
                Time.timeScale = 0;
                player.GetComponent<Char_Move>().enabled = false;
            }
        }

    }
    

    public IEnumerator loadNext(int sceneIndex)
    {
        //curtain_anim.SetBool("curtain_go", true);
        curtain.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneIndex);
    }
}
