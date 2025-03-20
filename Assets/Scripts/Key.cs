using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Key : MonoBehaviour
{
    PlayerInput playerinput;
    InputAction PickUp;
    public Item item = new Item("Item Name", 1);
    private bool pickUpZone = false;

    private void Start()
    {
        playerinput = GetComponent<PlayerInput>();
        PickUp = playerinput.actions.FindAction("PickUp");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            pickUpZone = true;
        }
    }

    public void addKeyToInv(InputAction.CallbackContext context)
    {
        if (pickUpZone == true && context.performed)
            Inventory.instance.AddItem(item);
        gameObject.SetActive(false);
    }
}


