using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClockPuzzleManager : MonoBehaviour
{

    //PlayerInput 
    PlayerInput playerInput;
    public playerMovement player;
    InputAction ClockAction;
    InputAction ClockExitAction;
    InputAction ClockForwardAction;
    InputAction ClockBackwardAction;

    //ClockHand GameObjects
    public GameObject hourHand;
    public GameObject minuteHand;
    //PlayerCam ref to disable it and then enable other camera to show clock 
    public Camera cam;
    public Camera playerCam;

    //Variables for triggers 
    private bool InClockRange;
    private float currentHourRotation;
    private float currentMinuteRotation;
    private bool isMinuteHandRotating;
    private bool isMinuteHandRotatingBackward;
    private bool isHourHandRotating;
    private bool isHourHandRotatingBackward;

    [SerializeField]
    private float rotationSpeed = 20f;

    private int targetHourCount = 4;
    private int targetMinuteCount = 5;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        ClockAction = playerInput.actions.FindAction("Padlock");
        ClockAction = playerInput.actions.FindAction("PadlockExit");
        ClockForwardAction = playerInput.actions.FindAction("ClockForward");
        ClockBackwardAction = playerInput.actions.FindAction("ClockBackward");

        cam.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMinuteHandRotating == true)
        {
            currentMinuteRotation += rotationSpeed * Time.deltaTime;
            minuteHand.transform.localRotation = Quaternion.Euler(0,0, currentMinuteRotation);
            
        }
        else if (isMinuteHandRotatingBackward == true)
        {
            currentMinuteRotation -= rotationSpeed * Time.deltaTime;
            minuteHand.transform.localRotation = Quaternion.Euler(0, 0, currentMinuteRotation);

        }


        if (isHourHandRotating == true)
        {
            currentHourRotation += rotationSpeed * Time.deltaTime;
            hourHand.transform.localRotation = Quaternion.Euler(0, 0, currentHourRotation);

        }

        else if (isHourHandRotatingBackward == true)
        {
            currentHourRotation -= rotationSpeed * Time.deltaTime;
            hourHand.transform.localRotation = Quaternion.Euler(0, 0, currentHourRotation);
        }

       
        OpenClock();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InClockRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InClockRange = false;
        }
    }

    public void FocousOnClock(InputAction.CallbackContext context)
    {
        if (context.performed && InClockRange == true)
        {
            playerCam.gameObject.SetActive(false);
            cam.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            player.enabled = false;
        }


    }

    public void RotateMinuteHandForward(InputAction.CallbackContext context)
    {
        if(context.started && InClockRange == true)
        {
            isMinuteHandRotating = true;
        }

        else if(context.canceled && InClockRange == true)
        {
            isMinuteHandRotating = false;
        }
    }

    public void RotateMinuteHandBackward(InputAction.CallbackContext context)
    {
        if (context.started && InClockRange == true)
        {
            isMinuteHandRotatingBackward = true;
        }

        else if (context.canceled && InClockRange == true)
        {
            isMinuteHandRotatingBackward = false;
        }
    }

    public void RotateHourHandForward(InputAction.CallbackContext context)
    {
        if (context.started && InClockRange == true)
        {
            isHourHandRotating = true;
        }

        else if (context.canceled && InClockRange == true)
        {
            isHourHandRotating = false;
        }
    }

    public void RotateHourHandBackward(InputAction.CallbackContext context)
    {
        if (context.started && InClockRange == true)
        {
            isHourHandRotatingBackward = true;
        }

        else if (context.canceled && InClockRange == true)
        {
            isHourHandRotatingBackward = false;
        }
    }


    public void ExitClock(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerCam.gameObject.SetActive(true);
            cam.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            player.enabled = true;
        }
    }


    private void OpenClock()
    {
        if(currentHourRotation == 4 && currentMinuteRotation == 5)
        {
            Debug.Log("PuzzleSolved");
        }
        
    }
}

