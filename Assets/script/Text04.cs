using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text04 : MonoBehaviour 
{
    public Vector3 offset;

    void OnTriggerStay(Collider collider)
    {
        if (LayerMask.NameToLayer("player") == collider.gameObject.layer)
            transform.GetChild(0).position = new Vector3(
                transform.GetChild(0).position.x,
                collider.transform.position.y + offset.y,
                transform.GetChild(0).position.z
            );
    }
}