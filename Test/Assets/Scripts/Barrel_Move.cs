using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Move : MonoBehaviour
{
    public Transform barrel_t;
    // Start is called before the first frame update
    void Start()
    {
        barrel_t = this.transform;
    }
    
    public void OnMouseDrag()
    {
        float screen_distance = Camera.main.WorldToScreenPoint(barrel_t.position).z;

        Vector3 move_pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,screen_distance));

        barrel_t.position = move_pos;

        barrel_t.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    public void OnMouseUp()
    {
        barrel_t.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
