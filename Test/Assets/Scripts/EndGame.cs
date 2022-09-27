using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject music;
    public GameObject curtain;
    public GameObject button1;
    public GameObject button2;
    public GameObject text;
    public GameObject text2;
    public AudioSource sfx;
    public Camera cam;

    void Awake(){
        music = GameObject.FindGameObjectWithTag("Music");
    }

    void Start(){
        music = GameObject.FindGameObjectWithTag("Music");
    }

    void OnMouseDown(){
        //kill music
        if (music!=null){
            Destroy(music);
        }
        StartCoroutine(end());
    }

    public IEnumerator end()
    {
        //curtain_anim.SetBool("curtain_go", true);
        curtain.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        //play explosion sound
        sfx.Play();
        yield return new WaitForSeconds(2.0f);
        cam.backgroundColor = Color.Lerp(Color.white, Color.white, 0);
        button1.SetActive(true);
        button2.SetActive(true);
        text.SetActive(true);
        curtain.SetActive(false);
        text2.SetActive(false);
    }
}
