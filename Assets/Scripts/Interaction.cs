using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction PickUpAction;
    InputAction NoteCloseAction;
    public playerMovement playermovement;
    
    
    private bool inPickUpRange;
    public GameObject NoteUI;
    public GameObject Interactiontext;
    public cameraController playercam;
    


    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        PickUpAction = playerInput.actions.FindAction("PickUp");
        NoteCloseAction = playerInput.actions.FindAction("NoteClose");
    }

    private void OnTriggerEnter(Collider other)
    {
        inPickUpRange = true;
        Interactiontext.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        inPickUpRange = false;
        Interactiontext.SetActive(false);
    }


    public void OpenNote(InputAction.CallbackContext context)
    {
        if(context.performed && inPickUpRange == true)
        {
            NoteUI.SetActive(true);
            Interactiontext.SetActive(true);
            playermovement.enabled = false;
            playercam.enabled = false;



        }

        
    }


    public void CloseNote(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            NoteUI.SetActive(false);

            playermovement.enabled = true;
            playercam.enabled = true;
        }
        

    }
}
