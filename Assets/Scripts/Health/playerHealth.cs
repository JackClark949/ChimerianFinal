using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class playerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;
    [SerializeField]
    private float currentHealth;

    float addHealth = 50f;

    public Healthbar healthbar;
    [SerializeField]
    float hpDeductTime = 1f;
    [SerializeField]
    public float nextHPDeductTime;



    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetSliderMax(currentHealth);






    }


    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }





    
   

    

    private void DeductHP()
    {
        float currentTime = Time.time;
        if (currentTime > nextHPDeductTime)
        {
            nextHPDeductTime = currentTime + hpDeductTime;
        }
    }



    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthbar.SetSliderMax(currentHealth);





       



    }

    //public void Healing()
    //{
        //currentHealth += addHealth;
        //if (currentHealth > 100)
        //{
            //currentHealth = 100;
        //}



    //}
}

    

