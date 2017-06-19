using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingColor : MonoBehaviour 
{
    public float rotatingSpeed, movingSpeed;
    Vector3 startingPos;

	void Start () 
    {
        startingPos = transform.position;
	}

	void Update () 
    {
        float posY = Mathf.Sin(Time.time * movingSpeed)/ 4;

        transform.position = new Vector3(startingPos.x, posY + startingPos.y, startingPos.z);

        transform.Rotate(new Vector3(
            0, 
            rotatingSpeed,
            0
        ));
	}

    void OnTriggerEnter(Collider collider)
    {
        Color color = transform.GetChild(0).GetComponent<MeshRenderer>().material.color;

        //collider.GetComponent<Light>().color = color;
        collider.GetComponent<MeshRenderer>().material.color = new Color(
            color.r,
            color.g,
            color.b,
            collider.GetComponent<MeshRenderer>().material.color.a
        );

        gameObject.SetActive(false);
    }
}