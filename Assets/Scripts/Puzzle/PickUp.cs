using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PickUp : MonoBehaviour
{
    //PlayerInput Ref and action
    //Player ref as key will be childed to player 
    PlayerInput playerinput;
    InputAction pickUp;
    public GameObject player;
    //'E' to pickup
    public GameObject PickUpText;
    //pickupzone bool
    private bool pickUpZone = false;

    private void Start()
    {
        playerinput = GetComponent<PlayerInput>();
        pickUp = playerinput.actions.FindAction("PickUp");
        PickUpText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //When player enters triggerzone 
        //PickupZone becomes true

        if (other.CompareTag("Player"))
        {
            PickUpText.SetActive(true);
            pickUpZone = true;
        }
    }
    //When player leaves becomes false
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpText.SetActive(false);
            pickUpZone = false;
        }


    }
    //If pickupzone is true and E is pressed
    //Sets Key to player
    //Sets key to set active(false)
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
