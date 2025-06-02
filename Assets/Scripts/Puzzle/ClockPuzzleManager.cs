using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClockPuzzleManager : MonoBehaviour
{

    //PlayerInput 
    PlayerInput playerInput;
    //Playermovement Ref and all ClockActions
    public playerMovement player;
    InputAction ClockAction;
    InputAction ClockExitAction;
    InputAction ClockForwardAction;
    InputAction ClockBackwardAction;
    InputAction HourHandAction;
    InputAction HourHandBackwardAction;

    //ClockHand GameObjects
    
    public GameObject HourHandPivot;
    public GameObject minuteHandPivot;
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

    //GrandFatherClockDrawer
    public ClockDrawer GrandFatherClock;

    [SerializeField]
    private float rotationSpeed = 20f;

    //Variables for clearing the puzzle
    //4:05 on clock to open drawer 
    private int targetHourCount = 4;
    private int targetMinuteCount = 5;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        ClockAction = playerInput.actions.FindAction("Clock");
        ClockAction = playerInput.actions.FindAction("ExitClock");
        ClockForwardAction = playerInput.actions.FindAction("ClockForward");
        ClockBackwardAction = playerInput.actions.FindAction("ClockBackward");
        InputAction HourHandAction = playerInput.actions.FindAction("HourHandForward");
        InputAction HourHandBackwardAction = playerInput.actions.FindAction("HourHandBackward");
        
        cam.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //When buttons held down making whatever hands bool true 
        if(isMinuteHandRotating == true)
        {
            //Rotates minutehand based on speed and deltatime making it smooth
            currentMinuteRotation += rotationSpeed * Time.deltaTime;
            //Applies updated rotation to MinuteHandPivot
            minuteHandPivot.transform.localRotation = Quaternion.Euler(currentMinuteRotation,0, 0);
            
        }
        //
        else if (isMinuteHandRotatingBackward == true)
        {
            //Same thing for this but this rotates backwards 
            currentMinuteRotation -= rotationSpeed * Time.deltaTime;
            minuteHandPivot.transform.localRotation = Quaternion.Euler(currentMinuteRotation, 0, 0);

        }


        if (isHourHandRotating == true)
        {
            currentHourRotation += rotationSpeed * Time.deltaTime;
            HourHandPivot.transform.localRotation = Quaternion.Euler(currentHourRotation, 0,0);

        }

        else if (isHourHandRotatingBackward == true)
        {
            currentHourRotation -= rotationSpeed * Time.deltaTime;
            HourHandPivot.transform.localRotation = Quaternion.Euler(currentHourRotation, 0, 0);
            
        }

       
        
    }
    //If player is in triggerzone in clockrange becomes true
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InClockRange = true;
        }
    }
    //When out of triggerzone becomes false 
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InClockRange = false;
        }
    }
    //When "E" is pressed and clockrange = true it will disable playercam and enable clockcam and disables playermovement
    public void FocousOnClock(InputAction.CallbackContext context)
    {
        if (context.performed && InClockRange == true)
        {
            playerCam.gameObject.SetActive(false);
            cam.gameObject.SetActive(true);
            
            player.enabled = false;
        }


    }
    //When button is held down so for MinuteHand when right arrow is held down MinuteHandRotating Forward is true
    //Then Left arrow is to make it go backwards
    //Hourhand is A and D held down 
    //If button is let go at any point it becomes false 
    public void RotateMinuteHandForward(InputAction.CallbackContext context)
    {
        if(context.started && InClockRange == true)
        {
            isMinuteHandRotating = true;
            OpenClock();
        }

        else if(context.canceled && InClockRange == true)
        {
            isMinuteHandRotating = false;
            OpenClock();
        }
    }

    public void RotateMinuteHandBackward(InputAction.CallbackContext context)
    {
        if (context.started && InClockRange == true)
        {
            isMinuteHandRotatingBackward = true;
            OpenClock();
        }

        else if (context.canceled && InClockRange == true)
        {
            isMinuteHandRotatingBackward = false;
            OpenClock();
        }
    }

    public void RotateHourHandForward(InputAction.CallbackContext context)
    {
        if (context.started && InClockRange == true)
        {
            isHourHandRotating = true;
            OpenClock();
        }

        else if (context.canceled && InClockRange == true)
        {
            isHourHandRotating = false;
            OpenClock();
        }
    }

    public void RotateHourHandBackward(InputAction.CallbackContext context)
    {
        if (context.started && InClockRange == true)
        {
            isHourHandRotatingBackward = true;
            OpenClock();
        }

        else if (context.canceled && InClockRange == true)
        {
            isHourHandRotatingBackward = false;
            OpenClock();
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
       
        //ClockFace is 360 because its a cirlce 
            //30 degress per hour clock has 12 hours on it 360/12 = 30
            //6 degress per minute hour has 60 minutes divide that by 30 then get 6 
            int hourCount = Mathf.RoundToInt(currentHourRotation / 30f);  
            int minuteCount = Mathf.RoundToInt(currentMinuteRotation / 6f); 

        //So when hourcount is 4 and minutecount is 5 
        //Puzzle Solved 
        //Re enables playercam and movement 
        //Opens GrandFatherClockDrawer
            if (hourCount == targetHourCount && minuteCount == targetMinuteCount)
            {
                cam.gameObject.SetActive(false);
                playerCam.gameObject.SetActive(true);
                GrandFatherClock.GrandFatherClockDrawer();
                player.enabled = true;
                Debug.Log("PuzzleSolved");
            }

           
        
        
    }
}

