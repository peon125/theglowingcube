using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRigidbody : MonoBehaviour
{
    public Vector3 speed;
    Rigidbody _rigidbody;

	void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddTorque(speed);
	}


	void Update()
    {
		
	}
}