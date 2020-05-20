using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    
    private int maxHealth = 100;

    private int currentHealth;

    private int amount;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void setCurrentDamage(int amount)
    {
        currentHealth -= amount;
    }

    public int getCurrentHealth()
    {
        return this.currentHealth;
    }

    public void ModefyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    // Update is called once per frame
    private void Update()
    {
        ModefyHealth(amount);
        if (Input.GetKeyDown(KeyCode.Space))
            ModefyHealth(-5);
        
         if (currentHealth == 0)
       {
            
       }

    }
}
