using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockBoundary00 : MonoBehaviour 
{
    public GameObject movingPlatform;
    public Vector3 speed;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == movingPlatform)
        {
            movingPlatform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            movingPlatform.GetComponent<Rigidbody>().velocity = speed;
        }
    }
}