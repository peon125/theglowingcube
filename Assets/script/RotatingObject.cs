using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour 
{
    public float speed, rotateXspeed, rotateYspeed, rotateZspeed;
    public bool dontMoveVerticaly;
    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        transform.Rotate(new Vector3(
            speed * rotateXspeed *  Time.deltaTime,
            speed * rotateYspeed *  Time.deltaTime,
            speed * rotateZspeed *  Time.deltaTime
        ));

        if (!dontMoveVerticaly)
        {
            float posY = Mathf.Sin(Time.time * speed) / 4;
            transform.position = new Vector3(transform.position.x, posY + startingPos.y, transform.position.z);
        }
    }
}