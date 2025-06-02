using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    //Enemy MaxHealth
    [SerializeField]
    float maxHealth = 40;
    [SerializeField]
    float currentHealth;
    //MiniEnemy Ref to be used later on to Instaniate 
    [SerializeField]
    GameObject MiniGil;
   


    private void Start()
    {
        //From the start set CurrentHealth to MaxHealth
        currentHealth = maxHealth;
    }

   

    //Take Method damage itself is a pass through in the WeaponScript it has a reference to this script and then passess through damage 
     public void TakeDamage(float damage)
     {
        //CurrentHealth - damage from Weapon should be 20 
         currentHealth -= damage;
        //If currentHealth reaches 0 Destroy Enemy 
         if (currentHealth == 0)
         {
             Destroy(gameObject);
         }
         //For every time TakeDamage is called it calls SpawnMiniGil
         //Whenever Shot a smaller enemy will Instaniate 
        spawnMiniGil();


     }


    private void spawnMiniGil()
    {
        //Mini Gil will spawn where main enemy is shot 
        Instantiate(MiniGil, transform.position, Quaternion.identity);
        
        

       
        
    }
}
