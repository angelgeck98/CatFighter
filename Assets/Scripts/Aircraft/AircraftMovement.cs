using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMovement : MonoBehaviour
{
    public float throttleIncrement = 0.1f;
    public float maxThrust = 200f;
    public float responsiveness = 10f;

    private float m_Throttle;
   
    
    
    private Rigidbody rb;
    
    private float responseModifier => (rb.mass / 10f) * responsiveness;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AdjustThrottle(float amount)
    {
        m_Throttle = Mathf.Clamp(m_Throttle + amount, 0f, 100f);

        Debug.Log($"Throttle: {m_Throttle}%");
    }


    public void Move(float roll, float pitch, float yaw)
    {
        rb.AddForce(transform.forward * (maxThrust * m_Throttle));

        rb.AddTorque(transform.up * (yaw * responseModifier));
        rb.AddTorque(transform.right * (pitch * responseModifier));
        rb.AddTorque(-transform.forward * (roll * responseModifier));

    }

}