using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class blockRotate2 : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction Rotate;
    private bool blockRotation = false;
    public MeshRenderer mesh;
    public Quaternion[] rotations;
    int currentRotation2 = 0;
    

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        Rotate = playerInput.actions.FindAction("Rotate");
        mesh = gameObject.GetComponentInChildren<MeshRenderer>();

        rotations = new Quaternion[]
        {
            Quaternion.Euler(60, 0, 0),
            Quaternion.Euler(30, 0, 0),
            Quaternion.Euler(80, 0, 0),
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            blockRotation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        blockRotation = false;
    }

    public void RotateBlock2(InputAction.CallbackContext context)
    {
        if (blockRotation == true && context.performed)
        {
            currentRotation2 = (currentRotation2 + 1) % rotations.Length;
            mesh.transform.rotation = rotations[currentRotation2];
            Debug.Log("Rotated 2");

             float xRotation2 = mesh.transform.rotation.eulerAngles.x;
        } 
    }



   
}
