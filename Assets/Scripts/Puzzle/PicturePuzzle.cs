using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PicturePuzzle : MonoBehaviour
{
    //PlayerInput
    PlayerInput playerInput;
    InputAction RotateAction;
   
    //Bool for InFrameRange
    private bool inFrameRange = false;
   
    //Keeps track of current rotation
    private int  currentRotation = 0;
   //Array of rotations puzzleframes cycle through
    private Quaternion[] rotations;

    public GameObject prompt;
    //Ref to other frame 
    public PicturePuzzle2 framePuzzle2;
    //Open drawer script when puzzle is solved it will call opendrawer function 
    public openDrawer openDrawer;
    
    
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        RotateAction = playerInput.actions.FindAction("Rotate");


        rotations = new Quaternion[]
        {
            Quaternion.Euler(0, 0, 0),
            Quaternion.Euler(90, 0, 0),
            Quaternion.Euler(180, 0, 0),
            Quaternion.Euler(-90,0, 0),
        };

        
       
      
       
    }

    
      

    private void OnTriggerEnter(Collider other)
    {
        //When in frames trigger zone sets interact prompt to true and frame range bool to true
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(true);
            inFrameRange = true;
        }
    }
    //then if exit becomes false
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(false);
            inFrameRange = false;
        }
    }
    //When 'E' is pressed and InFrameRange is true 
    public void RotatePainting(InputAction.CallbackContext context)
    {
        if (inFrameRange == true && context.performed)
        {
            //updates currentRotation
            currentRotation = (currentRotation + 1) % rotations.Length;
            //Apply new rotation to frame
            transform.rotation = rotations[currentRotation];

            
            Debug.Log(currentRotation);
            
            //Then once both paintings are solved 
            //Desk anim plays
            if (currentRotation == 0 && framePuzzle2.currentRotation == 0)
            {
                Debug.Log("Reached");
                //Disables Rotate when in place so paiting wont move anymore
                RotateAction.Disable();
                prompt.SetActive(false);
                openDrawer.playAnim();
            }
        }
        

    }


}
