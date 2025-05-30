using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewHealthBar : MonoBehaviour
{
   public Slider healthBar;
   public playerHealth playerHealth;

    void Update()
    {
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.currentHealth;
    }
}
