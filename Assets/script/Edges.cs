using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edges : MonoBehaviour 
{
    public Color selectedColor, unSelectedColor;
    public List<Transform> collidingEdges;
    Transform edges;

    void Start()
    {
        edges = transform;
    }

    public void Selected(Transform edge)
    {
        foreach (Transform _edge in edges)
        {
            if (_edge == edge)
            {
                _edge.GetComponent<MeshRenderer>().material.color = selectedColor;
            }
            else
            {
                _edge.GetComponent<MeshRenderer>().material.color = unSelectedColor;
            }
        }
    }
}