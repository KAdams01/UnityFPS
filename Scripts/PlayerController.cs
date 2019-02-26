using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public float lookSensitivity = 10f;
    private PlayerMotor motor;
    private float xRot = 0f;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;
        motor.Move(velocity);

        //Note: rotation around the Y axis turns from left to right, which requires mouse X to calculate
        //Note2: Up and down rotation should not be calculated on PLAYER, but on CAMERA instead, which is why it isn't here
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0,yRot,0) * lookSensitivity;
        motor.Rotate(rotation);
        //Camera rotation(UP/DOWN)
        xRot += Input.GetAxisRaw("Mouse Y") * lookSensitivity;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        Vector3 cameraRotation = new Vector3(xRot, 0, 0);
        motor.RotateCamera(cameraRotation);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            motor.Jump();
        }

    }
}
