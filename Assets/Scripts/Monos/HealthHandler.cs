using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    private void Awake()
    {
        healthBar.Init(currentHealth, maxHealth);
    }

    public int CurrentHealth
    {
        set
        {
            currentHealth = value > maxHealth ? maxHealth : value;
            if(currentHealth < 0)
            {
                currentHealth = 0;
            }
            healthBar.HealthChanged(currentHealth);
        }

        get
        {
            return currentHealth;
        }
    }

    public int MaxHealth
    {
        set
        {
            maxHealth = value < 1 ? 1 : value;

            if(maxHealth < currentHealth)
            {
                currentHealth = maxHealth;
            }
            healthBar.MaxHealthChanged(CurrentHealth);
        }

        get
        {
            return maxHealth;
        }
    }
}
