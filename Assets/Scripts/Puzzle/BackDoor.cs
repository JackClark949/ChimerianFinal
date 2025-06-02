using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BackDoor : MonoBehaviour
{
    Animation anim;
    private bool InDoorRange;
    public GameObject Player;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InDoorRange = true;
        }
        



    }

    public void OpenDoor(InputAction.CallbackContext context)
    {
        foreach (Transform child in Player.transform)
        {
            if (child.CompareTag("Key") && InDoorRange == true && context.performed)
            {
                anim.Play();
            }
        }
    }

    
}
