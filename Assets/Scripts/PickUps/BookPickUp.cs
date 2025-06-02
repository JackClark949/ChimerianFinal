using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BookPickUp : MonoBehaviour
{
    //PlayerInputRef and PickUpAction
    PlayerInput playerInput;
    InputAction pickUp;
    //PLayerRef as book is going to be added to the player as a child
    public GameObject player;
    //'E' to pickup text
    public GameObject PickUpText;

    //Each book has a pickupzone when you enter trigger it'll become true 
    private bool pickUpZone = false;
    //Public bool as it's needed in bookshelf puzzle
    //When Book is picked up this will become false 
    //In bookshelf puzzle picking up handeled through a menu 
    public bool CanBePickedUp = true;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        pickUp = playerInput.actions.FindAction("PickUp");
        PickUpText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If gameobject with player tag comes into trigger zone pickupzone becomes true and book can be pickedup
        if (other.CompareTag("Player"))
        {
            PickUpText.SetActive(true);
            pickUpZone = true;
        }
    }
    //Then if player leaves becomes false
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpText.SetActive(false);
            pickUpZone = false;
        }


    }
    //If PickUpZone = true and player presses 'E'
    public void AddBookToPlayer(InputAction.CallbackContext context)
    {
        //So when pickupzone is true and E is pressed and canbepicked up is true
        //it'll set the book as a child to parent and then it will be disabled

        if (pickUpZone == true && context.performed && CanBePickedUp == true)
        {
            gameObject.transform.SetParent(player.transform);
            gameObject.SetActive(false);
            PickUpText.SetActive(false);
            
        }
    }

}
