using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHolderTrigger2 : MonoBehaviour
{
    public bool inBookHolderRange2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inBookHolderRange2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        
            inBookHolderRange2 = false;
        
    }

}
