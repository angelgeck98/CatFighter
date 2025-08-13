using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMovement : MonoBehaviour
{
    public float throttleIncrement = 0.1f;
    public float maxThrottle = 200f;
    public float responsiveness = 10f;
    
    
    Rigidbody rb;
    
    private float ResponseModifier => (rb.mass / 10f) * responsiveness;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(float throttle, float roll, float pitch, float yaw)
    {
        rb.AddForce(transform.forward * maxThrottle * throttle);
        rb.AddTorque(transform.up * yaw * ResponseModifier);
        rb.AddTorque(transform.right * pitch * ResponseModifier);
        rb.AddTorque(-transform.forward * roll * ResponseModifier);
        
    }
    
}