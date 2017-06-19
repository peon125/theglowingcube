using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour 
{
    void OnTriggerEnter(Collider collider)
    {
        if (LayerMask.NameToLayer("player") == collider.gameObject.layer)
        {
            GameController._instance.CollectObjective();
            AudioController._instance.PlaySound("objective");

            gameObject.SetActive(false);
        }
    }
}