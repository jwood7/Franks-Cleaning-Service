using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard_Gen : MonoBehaviour
{
    public GameObject keycard_obj;
    //public float x_pos;
    //public float y_pos;
    public List<Transform> barrels;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 barrel_pos = barrels[Random.Range(0,barrels.Count)].position;
        //x_pos = Random.Range(-8.25f,8.25f);
        //y_pos = Random.Range(-2.5f, 3.5f);
        Instantiate(keycard_obj, barrel_pos, keycard_obj.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
