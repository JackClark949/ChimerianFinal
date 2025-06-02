using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    //PlayerInputRef, PickUpAction, NoteCloseAction
    PlayerInput playerInput;
    InputAction PickUpAction;
    InputAction NoteCloseAction;
    //PlayerMovementRef when Note is on screen don't want player to move this is same for the camera 

    public playerMovement playermovement;
    
    //Bool for when in trigger zone 
    private bool inPickUpRange;
    //Note UI 
    public GameObject NoteUI;
    //Prompt "E" to Interact
    public GameObject Interactiontext;
    public cameraController playercam;
    


    private void Start()
    {
        //Grabs Componets 
        playerInput = GetComponent<PlayerInput>();
        PickUpAction = playerInput.actions.FindAction("PickUp");
        NoteCloseAction = playerInput.actions.FindAction("NoteClose");
    }

    //Trigger for the note 
    //Only Player can Interact with notes as it compares tags and checks if its the player
    //If it is an object with playerTag InPickUpRange becomes true and Prompt becomes enabled 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inPickUpRange = true;
            Interactiontext.SetActive(true);
        }
        
    }
    //When Player leaves trigger Area 
    //Bool becomes false and prompt becomes false wont show up
    private void OnTriggerExit(Collider other)
    {
        inPickUpRange = false;
        Interactiontext.SetActive(false);
    }

    //Only when InPickUpRange == true and 'E' is pressed will note be displayed
    //Disables PlayerMovement and cameraController so when Note is on Screen player can't move
    public void OpenNote(InputAction.CallbackContext context)
    {
        if(context.performed && inPickUpRange == true)
        {
            NoteUI.SetActive(true);
            Interactiontext.SetActive(false);
            playermovement.enabled = false;
            playercam.enabled = false;



        }

        
    }

    //Then when 'ESC' is pressed Note is disabled and playermovement and playercam are renabled 
    public void CloseNote(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            NoteUI.SetActive(false);
            Interactiontext.SetActive(true);   
            playermovement.enabled = true;
            playercam.enabled = true;
        }
        

    }
}
