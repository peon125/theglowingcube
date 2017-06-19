using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour 
{
    public Transform relatedObject;
    public Vector3 offset;

    void Update() 
    {
        transform.position = relatedObject.position + offset;
    }
}