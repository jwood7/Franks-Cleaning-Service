using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill_Border : MonoBehaviour
{
    public GameObject curtain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            StartCoroutine(loadNext(3));
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
