using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    public Camera cam;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    private bool isGrounded;

    private Rigidbody rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            cam.transform.localEulerAngles = -cameraRotation;
        }
    }

    void PerformMovement()
    {
            if (velocity != Vector3.zero)
            {
                //rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
                rb.AddForceAtPosition(velocity*40, cam.transform.forward, ForceMode.Force);
            }


    }

    internal void Jump()
    {
        if (isGrounded)
        {
            rb.velocity += Vector3.up * 3;
            isGrounded = false;
        }
    }
}
