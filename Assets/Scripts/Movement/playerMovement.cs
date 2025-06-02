using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    //PlayerInputRef, MoveActionRef
    private PlayerInput playerInput;
    private InputAction moveAction;
    //CharacterChar to handle movement 
    CharacterController controller;

    //PlayerSpeed speed player will move at 
    [SerializeField]
    float playerSpeed = 5f;

    void Start()
    {
        //Grab components and playerInput find "Move" Action so 'W' 'A' 'S' 'D' can move the player around
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        //CharacterController to handle movement 
        controller = GetComponent<CharacterController>();
        
    }

   
    void Update()
    {
        //Reads movement input from Player
        Vector2 direction = moveAction.ReadValue<Vector2>();
        //Taken from
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        //Prevents Camera Up/Down Movement
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        //Normalizes Camera direction 
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = cameraForward * direction.y + cameraRight * direction.x;
        //CharacterController moves player with speed and by delaTime to make it consistent
        controller.Move(movement * playerSpeed * Time.deltaTime);
        //SimpleMove was used to apply Gravity 
        controller.SimpleMove(movement * playerSpeed * Time.deltaTime);
        


       

       
    

}

  
    //Not needed anymore
    /*public void Crouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.localScale = new Vector3(1f, 0.5f, 1f);
        }
        else 
        { transform.localScale = new Vector3(1f, 1f, 1f); }

    }*/


    

    

}

