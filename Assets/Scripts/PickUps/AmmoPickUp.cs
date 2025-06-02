using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AmmoPickUp : MonoBehaviour
{
    //WeaponScript Ref
    Weapon weaponScript;
    //PickUpZone bool 
    bool inPickUpZone = false;
    //PlayInput ref and action
    PlayerInput playerInput;
    InputAction pickUpAction;
    

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        pickUpAction = playerInput.actions.FindAction("PickUp");
        weaponScript = GameObject.FindWithTag("Weapon").GetComponent<Weapon>();
        
        
    }
    
    //When In triggerzone pickupzone becomes true
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            inPickUpZone = true;
        }
    }

    //When out of it false so pickup can't be activated anywhere
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inPickUpZone = false;
        }
    }

    //If 'E' is pressed and PickUpZone = true
    //Passess through 5 Ammo to WeaponScript witch is then added to MaxAmmo
    public void UseAmmoPickUp(InputAction.CallbackContext context)
    {
        if(context.performed && inPickUpZone == true)
        {
            weaponScript.AddAmmo(5);
            //Destroys itself after
            Destroy(gameObject);
           
           
        }
    }
}
