using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AmmoPickUpDebug : MonoBehaviour
{
    public Weapon weaponScript;
    bool inPickUpZone = false;
    PlayerInput playerInput;
    InputAction pickUpAction;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        pickUpAction = playerInput.actions.FindAction("PickUp");
        if(weaponScript != null)
        {
            weaponScript = GameObject.FindWithTag("Weapon").GetComponent<Weapon>();
        }
        
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            inPickUpZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inPickUpZone = false;
        }
    }

    public void UseAmmoPickUp(InputAction.CallbackContext context)
    {
        if (context.performed && inPickUpZone == true)
        {
            //weaponScript.AddAmmo(5);
            weaponScript.UpdateAmmoText();
            Destroy(gameObject);
            
            Debug.Log("Added 5 Ammo");
        }
    }
}

