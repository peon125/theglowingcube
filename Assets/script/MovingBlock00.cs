using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock00 : MonoBehaviour 
{
    public Vector3 speed;
    public Collider boundary0, boundary1;
    Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = speed;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider == boundary0 || collider == boundary1)
            _rigidbody.velocity = -_rigidbody.velocity;
    }
}