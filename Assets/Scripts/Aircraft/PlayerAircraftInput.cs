using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAircraftInput : MonoBehaviour
{
  
  private AircraftMovement m_Movement;
  public float mouseSensitivity = 115f;

  private float throttle = 0f;
  
  void Awake()
  {
    m_Movement = GetComponent<AircraftMovement>();
    
    Cursor.lockState = CursorLockMode.Locked; // keeps cursor in center of screen
    Cursor.visible = false;                   
  }


  void FixedUpdate()
  {

    HandleInput();

  }

  void HandleInput()
  {
    // Throttle
    if (Input.GetKey(KeyCode.Space))
      throttle = Mathf.Clamp01(throttle + 10f);
    if (Input.GetKey(KeyCode.S))
      throttle = Mathf.Clamp01(throttle - 20f);
    
    
    float yaw = 0f;
    if (Input.GetMouseButton(0)) //yaw
      yaw = -Input.GetAxis("Mouse X") * -mouseSensitivity;

    float pitch = 0f;
    if (Input.GetMouseButton(0)) // pitch only when left mouse button held
      pitch = -Input.GetAxis("Mouse Y") * mouseSensitivity;

    float roll = Input.GetKey(KeyCode.Q) ? -1f : Input.GetKey(KeyCode.E) ? 1f : 0f;

    // Apply movement to AircraftMovement
    m_Movement.Move(throttle, roll, pitch, yaw);
    

  }
  
}
