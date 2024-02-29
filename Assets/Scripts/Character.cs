using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected HealthHandler healthHandler;
    [SerializeField] protected Relation relation;
        
    public Relation Relation { get => relation; set => relation = value; }

    private void OnMouseDown()
    {
        GameEvents.RaiseCharacterClicked(this);
    }
    
    public void Damage(int damage)
    {
        healthHandler.CurrentHealth -= damage;
    }

    public void Heal(int amount)
    {
        healthHandler.CurrentHealth += amount;
    }

    public abstract void TakeTurn();
}

public enum Relation
{
    ANY,
    FRIENDLY,
    UNFRIENDLY,
    SELF
}
