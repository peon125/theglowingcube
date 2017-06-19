using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text01 : MonoBehaviour 
{
    public Transform relatedObject;
    public Vector3 offset;
    public string secondText;
    public Vector2 secondSize;
    public Vector3 secondPosition;

	void Update() 
    {
        if (relatedObject.gameObject.activeInHierarchy)
        {
            transform.position = relatedObject.position + offset;
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        transform.position = secondPosition;
        transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = secondSize;
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = secondText;
    }
}