using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour 
{
    public Vector3 position;

    void OnTriggerEnter(Collider collid)
    {
        GameController._instance.lastCheckpoint = position;
        AudioController._instance.PlaySound("checkpoint");

        gameObject.SetActive(false);
    }
}