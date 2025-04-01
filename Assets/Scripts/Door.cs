/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    private bool InDoorRange;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (CompareTag("Player"))
        {
            animator.SetBool("isOpen", true);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
       

        if (CompareTag("Player"))
        {
            animator.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InDoorRange = false;

        if (CompareTag("Player"))
        {
            animator.SetBool("isOpen", false);
        }
        
        
    }









}
*/