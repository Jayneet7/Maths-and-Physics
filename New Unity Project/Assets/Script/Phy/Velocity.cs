using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    public float speed;
    public float angularSpeed;
    protected Rigidbody cube;

    void Start()
    {
        cube = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        speed = cube.velocity.magnitude;
        angularSpeed = cube.angularVelocity.magnitude;

        // To sumulate this add force you have to disable the graivty
        cube.AddForce(Vector3.forward);


    }
}