using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    //Taken From: https://youtu.be/f473C43s8nE?si=WzRwnpwT5Rzsl8ot


    public float mouseSensitivity = 100f;//Mouse Sens 

    float xRotation = 0f;

    //PlayerRef
    public Transform player;

    void Start()
    {
        //Locks Cursor on start 
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Read MouseInput
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        //Clamps XRotation so Player can't look too far up or down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Applies rotation to Camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Rotate the player with the Camera 
        player.Rotate(Vector3.up * mouseX);
        
    }
}
