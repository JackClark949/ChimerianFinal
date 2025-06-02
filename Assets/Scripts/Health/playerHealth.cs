using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class playerHealth : MonoBehaviour
{
    //PlayerMaxHealthRef
    [SerializeField]
    public float maxHealth = 100f;
    //CurrentHealthRef
    [SerializeField]
    public float currentHealth;







    private void Start()
    {
        //On Start currentHealth = MaxHealth
        currentHealth = maxHealth;

    }


    private void Update()
    {
        //Constantly checks to see if currentHealth is greater than MaxHealth and if it is will set back to Max
        //This is in place mainly for HealthPickUps and to make sure it can't exceed maxHealth
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        //If currentHealth reaches 0 destroys the player 
        else if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }


    }

    //Amount is damage player will recieve 
    //EnemyAttacking script has a ref to PlayerHealth and when this method is called amount is passed through
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        
    }

    //HealthPickUp 
    //When it's picked up it will call this method and pass through AddedHealth
    public void AddHealth(float AddedHealth)
    {
        currentHealth += AddedHealth;
    }
}

    

