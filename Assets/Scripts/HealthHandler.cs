using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public delegate void damageTaken(int damage);
    public event damageTaken DamageTaken;

    public delegate void maxHealthChanged(int value);
    public event maxHealthChanged MaxHealthChanged;

    public int CurrentHealth
    {
        set
        {
            currentHealth = value > maxHealth ? maxHealth : value;
            DamageTaken?.Invoke(currentHealth);
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

            MaxHealthChanged?.Invoke(maxHealth);
        }

        get
        {
            return maxHealth;
        }
    }
}
