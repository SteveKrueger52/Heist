using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Range(0,20)]    public float maxSpeed;         // Maximum attainable velocity (omnidirectional)
    [Range(0,20)]    public float maxDeltaSpeed;    // Maximum attainable acceleration (omnidirectional)
    [Range(0,1)]     public float movementDeadzone;

    public GameObject heldItems;
    private Vector3 handAnchor;

    // See Bottom for implementation
    public AnimCurveSet HeadBob;

    private Vector3 vel = Vector2.zero;
    private Vector3 accel = Vector2.zero;
    private Rigidbody rb;
    private Camera cam;
    private Vector3 camAnchor;
    
    
// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cam = GetComponentInChildren<Camera>();
        camAnchor = cam.transform.localPosition;
        handAnchor = heldItems.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        UpdateMove();
        if (vel.magnitude != 0)
        {
            cam.transform.localPosition = camAnchor + HeadBob.getHeadOffset(Time.deltaTime);
            heldItems.transform.localPosition = handAnchor + HeadBob.getItemOffset(0);
        }
    }

    void UpdateMove()
    {
        // Get Input, scale to Acceleration
        Vector3 steering = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        steering = steering.magnitude > 1 ? steering.normalized : steering;
        
        // Adjust for local rotation
        steering = steering.x * transform.right + steering.z * transform.forward;

        if (steering.magnitude < movementDeadzone) // No input, stop
            accel = vel.magnitude > maxDeltaSpeed ? -vel.normalized * maxDeltaSpeed : -vel;
        else
            accel = steering * maxDeltaSpeed;
        
        // Apply Acceleration
        vel = Vector3.ClampMagnitude(vel + accel, maxSpeed);
        
        // Apply Velocity
        rb.velocity = vel;
    }
}
