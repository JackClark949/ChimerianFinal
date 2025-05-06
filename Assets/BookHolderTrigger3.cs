using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHolderTrigger3 : MonoBehaviour
{
    public bool inBookHolderRange3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inBookHolderRange3 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        
            inBookHolderRange3 = false;
        
    }


}
