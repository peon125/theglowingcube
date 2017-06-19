using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour 
{
    Cube cube;

	void Start() 
    {
        cube = transform.parent.parent.GetComponent<Cube>();
    }

    void OnTriggerEnter(Collider collider)
    {
        cube.collidingEdges.Add(transform);
    }

    void OnTriggerExit(Collider collider)
    {
        cube.collidingEdges.Remove(transform);
    }
}