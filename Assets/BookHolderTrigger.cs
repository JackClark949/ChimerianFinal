using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHolderTrigger : MonoBehaviour
{
    public bool inBookHolderRange1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inBookHolderRange1 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        
            inBookHolderRange1 = false;
        
    }
}
