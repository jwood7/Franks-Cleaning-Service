using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning_Activate : MonoBehaviour
{
    public GameObject warning_label;
    public bool toggle_label = false;

    public void OnMouseDown()
    {
        toggle_label = !toggle_label;
        warning_label.SetActive(toggle_label);
    }
}
