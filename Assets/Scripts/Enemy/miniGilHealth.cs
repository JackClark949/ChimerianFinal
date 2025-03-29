using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniGilHealth : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100;

    private float currentHealth; 


    void Start()
    {
        currentHealth = maxHealth;
    }

   public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
   
}
