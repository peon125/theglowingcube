using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy00 : MonoBehaviour 
{
    public bool destroynOnMapTouch;

    void OnTriggerEnter(Collider collider)
    {
        if (destroynOnMapTouch && LayerMask.NameToLayer("map") == collider.gameObject.layer)
            gameObject.SetActive(false);
        else if (LayerMask.NameToLayer("player") == collider.gameObject.layer)
            GameController._instance.Lose();
    }
}