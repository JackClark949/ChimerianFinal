using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class playerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;

    [SerializeField]
    float currentHealth;
    float addHealth = 50f;

    public Healthbar healthbar; 


    [SerializeField]
    float hpDeductTime = 1f;
    [SerializeField]
    public float nextHPDeductTime;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetSliderMax(maxHealth);
        
    }

    private void DeductHP()
    {
        float currentTime = Time.time;
        if (currentTime > nextHPDeductTime)
        {
            nextHPDeductTime = currentTime + hpDeductTime;
        }
    }



    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthbar.SetSlider(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }



    }

    public void Healing()
    {
        currentHealth += addHealth;
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }



    }
}

    

