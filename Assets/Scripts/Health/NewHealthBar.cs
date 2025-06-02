using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewHealthBar : MonoBehaviour
{
    //Slider for HealthBar 
   public Slider healthBar;
    //PLayerHealthRef
   public playerHealth playerHealth;

    void Update()
    {
        //Sliders maxvalue will always be PlayersMaxHealth
        healthBar.maxValue = playerHealth.maxHealth;
        //Slider current value will always be Players currentHealth
        healthBar.value = playerHealth.currentHealth;
    }
}
