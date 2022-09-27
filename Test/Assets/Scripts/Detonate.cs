using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detonate : MonoBehaviour
{
    public int Stage;
    public GameObject curtain;
    public GameObject detonate;
    public int textCount = -1;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && textCount == 0){
            //textCount = 1;
            //detonate.SetActive(false);
            Time.timeScale = 1;
            StartCoroutine(loadNext(Stage));
        } 
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            detonate.SetActive(true);
            textCount = 0;
            Time.timeScale = 0;
            player.GetComponent<Char_Move>().enabled = false;
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
