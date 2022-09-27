using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Interact : MonoBehaviour
{
    public bool can_interact;
    public GameObject player;
    public GameObject dialog_box_obj;
    // Start is called before the first frame update
    void Start()
    {
        can_interact = false;
        dialog_box_obj.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ( can_interact && Input.GetKeyDown(KeyCode.E))
        {
            dialog_box_obj.SetActive(true);
            player.GetComponent<Char_Move>().enabled = false;
        }
        if (can_interact && Input.GetKeyDown(KeyCode.Escape))
        {
            dialog_box_obj.SetActive(false);
            player.GetComponent<Char_Move>().enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("collided");
            can_interact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            can_interact = false;
        }
    }
}
