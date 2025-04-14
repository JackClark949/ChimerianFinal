using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PickUp : MonoBehaviour
{
    PlayerInput playerinput;
    InputAction pickUp;
    public GameObject player;
    public GameObject PickUpText;
    
    private bool pickUpZone = false;

    private void Start()
    {
        playerinput = GetComponent<PlayerInput>();
        pickUp = playerinput.actions.FindAction("PickUp");
        PickUpText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            PickUpText.SetActive(true);
            pickUpZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpText.SetActive(false);
            pickUpZone = false;
        }


    }

    public void addKeyToPlayer(InputAction.CallbackContext context)
    {
        if(pickUpZone == true && context.performed)
        {
            gameObject.transform.SetParent(player.transform);
            PickUpText.SetActive(false );
            gameObject.SetActive(false);
            Debug.Log("Added Key to player");

        }
    }
}
