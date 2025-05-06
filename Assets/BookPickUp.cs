using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BookPickUp : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction pickUp;
    public GameObject player;
    public GameObject PickUpText;

    private bool pickUpZone = false;
    public bool CanBePickedUp = true;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        pickUp = playerInput.actions.FindAction("PickUp");
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

    public void AddBookToPlayer(InputAction.CallbackContext context)
    {
        if (pickUpZone == true && context.performed && CanBePickedUp)
        {
            gameObject.transform.SetParent(player.transform);
            gameObject.SetActive(false);
            PickUpText.SetActive(false);
            playerInput.DeactivateInput();
        }
    }

}
