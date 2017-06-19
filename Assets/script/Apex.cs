using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apex : MonoBehaviour 
{
    public Color errorColor, colorNotSel, colorSel, regularEdgeColor;
    public MeshRenderer relatedApex, relatedEdge;
    public bool isGrounded, isSelected;
    Material material;

    public GameObject brick;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    public void Selected(bool b)
    {
        if (b)
        {
            material.color = colorSel;
            relatedApex.material.color = colorSel;
            relatedEdge.material.color = colorSel;
        }
        else
        {
            material.color = colorNotSel;
            relatedApex.material.color = colorNotSel;
            relatedEdge.material.color = regularEdgeColor;
        }
    }

    public void Error()
    {
        material.color = errorColor;
        relatedApex.material.color = errorColor;
    }

    void OnTriggerStay(Collider collider)
    {
        if (LayerMask.NameToLayer("map") == collider.gameObject.layer && collider.tag != "cantAttach")
        {
            isGrounded = true;
            brick = collider.gameObject;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (LayerMask.NameToLayer("map") == collider.gameObject.layer)
        {
            isGrounded = false;
        }
    }
}