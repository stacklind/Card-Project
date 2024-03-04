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

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public void Damage(int damage)
    {
        healthHandler.CurrentHealth -= damage;
        if(healthHandler.CurrentHealth == 0)
        {
            GameEvents.RaiseCharacterDied(this);
            Die();
        }
    }

    public void Heal(int amount)
    {
        healthHandler.CurrentHealth += amount;
    }

    public abstract void TakeTurn();
    public virtual void EndTurn()
    {
        GameEvents.RaiseCharacterDoneWithTurn();
    }
}

public enum Relation
{
    ANY,
    FRIENDLY,
    UNFRIENDLY,
    SELF
}
