using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 40;
    [SerializeField]
    float currentHealth;
    [SerializeField]
    GameObject MiniGil;
   


    private void Start()
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

        spawnMiniGil();


     }


    private void spawnMiniGil()
    {
        
        Instantiate(MiniGil, transform.position, Quaternion.identity);
        
        

       
        
    }
}
