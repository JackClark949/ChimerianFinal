using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHolderTrigger : MonoBehaviour
{
    //I wasn't really sure of any other way to do this
    //For the BookShelfPuzzle it has 3 holders where the books go
    //When you're in their trigger zones you can then place a book
    //So I made 3 scripts for the 3 holders 
    //Public bool as needs to be accessed in BookShelf Puzzle
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
