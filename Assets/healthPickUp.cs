using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class healthPickUp : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction PickUpAction;
    public playerHealth playerHealth;

    private float AddHealth = 20f;
    private bool inPickUpRange = false;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        PickUpAction = playerInput.actions.FindAction("PickUp");
        if (playerHealth != null)
        {
            playerHealth = GameObject.FindWithTag("Player").GetComponent<playerHealth>();
        }

    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inPickUpRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inPickUpRange = false;
        }
    }

    public void AddHealthToPlayer(InputAction.CallbackContext context)
    {
        if(inPickUpRange == true && context.performed)
        {
            playerHealth.Healing(AddHealth);
            Destroy(gameObject);
        }
    }
}
