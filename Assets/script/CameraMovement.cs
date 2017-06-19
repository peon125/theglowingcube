using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour 
{
    public Transform characterToFollow, background;
    public bool followCharacter;
    public float speed;
    public Vector2 offset;
    Vector3 dragOrigin;
    Vector2 boundaries;

    void Start()
    {
        followCharacter = true;

        boundaries = new Vector2(
            background.localScale.x / 2 + offset.x,
            background.localScale.y / 2 + offset.y
        );
    }

    void LateUpdate()
    {
        if (followCharacter)
            ComeOnCatchUp();
    }

    public void ComeOnCatchUp()
    {
        transform.position = new Vector3(
            characterToFollow.position.x,
            characterToFollow.position.y,
            -20
        ); 

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -boundaries.x, boundaries.x),
            Mathf.Clamp(transform.position.y, -boundaries.y, boundaries.y),
            transform.position.z
        );
    }

    public void Drag()
    {
        if (Input.touchCount == 1)
        {
            Vector3 v3 = new Vector3(-Input.GetTouch(0).deltaPosition.x, -Input.GetTouch(0).deltaPosition.y, 0);
            v3 *= speed;
            transform.position += v3;

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -boundaries.x, boundaries.x),
                Mathf.Clamp(transform.position.y, -boundaries.y, boundaries.y),
                transform.position.z
            );
        }
    }

    public void StartDragging()
    {
        //TODO zesrac sie xD
    }
}