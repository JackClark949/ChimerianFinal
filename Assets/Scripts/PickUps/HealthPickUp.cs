using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthPickUp : MonoBehaviour
{
   //PlayerInput
   PlayerInput playerInput;
   InputAction PickUpAction;

    playerHealth playerHealth;

    private bool InPickUpRange = false;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        PickUpAction = playerInput.actions.FindAction("PickUp");
        playerHealth = GameObject.FindWithTag("Player").GetComponent<playerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InPickUpRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InPickUpRange = false;
        }
    }

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
