using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text03 : MonoBehaviour 
{
    void OnTriggerEnter(Collider collider)
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}