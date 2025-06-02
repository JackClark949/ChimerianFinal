using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class miniGilHealth : MonoBehaviour
{
    //MaxHealth
    [SerializeField]
    float maxHealth = 100;
    //CurrentHealth
    private float currentHealth; 


    void Start()
    {
        //Make sure currentHealth is max at start
        currentHealth = maxHealth;
    }

    //WeaponScript passes in damage with its reference in that script
    //Once currentHealth = 0 destroy miniEnemy
   public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
   
}
