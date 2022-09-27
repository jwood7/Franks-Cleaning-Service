using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public float health_amt;
    public float maxHealth = 100f;
    public TextMeshProUGUI health_text;
    public GameObject curtain;
    public HealthBar healthBar;
    public int SceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        health_amt = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //curtain = GameObject.FindGameObjectWithTag("Curtain");
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(health_amt);
        //health_text.text = "Health: " + health_amt.ToString() + "%";
        if(health_amt <= 0){
            StartCoroutine(loadNext(SceneIndex));
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
