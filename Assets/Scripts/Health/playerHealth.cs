using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class playerHealth : MonoBehaviour
{
    [SerializeField]
    public float maxHealth = 100f;
    [SerializeField]
    public float currentHealth;







    private void Start()
    {
        currentHealth = maxHealth;

    }


    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        else if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }


    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        
    }

    public void AddHealth(float AddedHealth)
    {
        currentHealth += AddedHealth;
    }
}

    

