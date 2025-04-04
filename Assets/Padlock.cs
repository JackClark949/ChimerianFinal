using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Padlock : MonoBehaviour
{

    PlayerInput playerInput;
    public playerMovement player;
    InputAction padLockAction;
    InputAction padLockExitAction;
    InputAction WheelRotateAction;
    //Padlock Camera
    public Camera cam;
    //PlayerCam
    public Camera playerCam;
    //Trigger to set this camera to the padlock
    private bool InPadlockRange;
    private int CurrentWheelRotation = 0;
    private int CurrentWheelRotation2 = 0;
    private int CurrentWheelRotation3 = 0;




    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        padLockAction = playerInput.actions.FindAction("Padlock");
        padLockExitAction = playerInput.actions.FindAction("PadlockExit");
        WheelRotateAction = playerInput.actions.FindAction("WheelRotate");

        cam.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        UnlockPadLock();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InPadlockRange = true;
        }
    }



    public void FocousOnPadlock(InputAction.CallbackContext context)
    {
        //If 'E' is pressed and player is in trigger range sets camera to true
        if (context.performed && InPadlockRange == true)
        {
            //Padlock Camera is set to true and cursor is unlocked playermovement and cam disabled
            playerCam.gameObject.SetActive(false);
            cam.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            player.enabled = false;

        }


    }
    public void ExitPadlock(InputAction.CallbackContext context)
    {
        //If 'ESC' is pressed backs out of Padlock view
        if (context.performed)
        {
            playerCam.gameObject.SetActive(true);
            cam.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            player.enabled = true;
        }
    }

    public void WheelRotate(InputAction.CallbackContext context)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (context.performed && hit.collider.CompareTag("Wheel 1") && InPadlockRange == true)
            {
                transform.GetChild(1).transform.Rotate(0, 0, -40);
                CurrentWheelRotation++;
                Debug.Log(CurrentWheelRotation);
            }
            else if (CurrentWheelRotation >= 8)
            {
                CurrentWheelRotation = 0;
            }

            if (context.performed && hit.collider.CompareTag("Wheel 2") && InPadlockRange == true)
            {
                transform.GetChild(2).transform.Rotate(0, 0, -40);
                CurrentWheelRotation2++;
            }
            else if (CurrentWheelRotation2 >= 8)
            {
                CurrentWheelRotation2 = 0;
            }

            if (context.performed && hit.collider.CompareTag("Wheel 3") && InPadlockRange == true)
            {
                transform.GetChild(3).transform.Rotate(0, 0, -40);
                CurrentWheelRotation3++;

            }

            else if (CurrentWheelRotation3 >= 8)
            {
                CurrentWheelRotation3 = 0;
            }



        }




    }

    private void UnlockPadLock()
    {
        if (CurrentWheelRotation == 3 && CurrentWheelRotation2 == 7 && CurrentWheelRotation3 == 4)
        {
            Debug.Log("Unlocked");
        }
    }





}
