using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthPickUp : MonoBehaviour
{
   //PlayerInput
   PlayerInput playerInput;
   InputAction PickUpAction;
    //PlayerHealth Ref
    playerHealth playerHealth;

    //PickUpRange
    private bool InPickUpRange = false;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        PickUpAction = playerInput.actions.FindAction("PickUp");
        playerHealth = GameObject.FindWithTag("Player").GetComponent<playerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player enters trigger zone bool becomes true
        if (other.CompareTag("Player"))
        {
            InPickUpRange = true;
        }
    }
    //If out becomes false 
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InPickUpRange = false;
        }
    }
    //So if PlayerHealth is already at 100 or equal to it 
    //HealthPickUp won't do anything it'll only work when Health is less 
    //If 'E' is pressed and pickuprange = true and health is less than 100 
    //Calls Playerhealth addHealth function and passess through 20 which is added to current health 
    public void UseHealthPickUp(InputAction.CallbackContext context)
    {

        if (playerHealth.currentHealth >= 100)
        {
            return;

        }
        if (InPickUpRange == true && context.performed)
        {
            playerHealth.AddHealth(20);
            Destroy(gameObject);
        }

    }
}
