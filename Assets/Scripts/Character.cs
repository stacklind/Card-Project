using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private HealthHandler healthHandler;
    [SerializeField] private Relation relation;
    private Behaviour behaviour;

    public Relation Relation { get => relation; set => relation = value; }

    private void OnMouseDown()
    {
        GameEvents.RaiseCharacterClicked(this);
    }

    public void Init(Behaviour behaviour)
    {
        this.behaviour = behaviour;
        behaviour.Init(this);
    }

    public void Damage(int damage)
    {
        healthHandler.CurrentHealth -= damage;
    }

    public void Heal(int amount)
    {
        healthHandler.CurrentHealth += amount;
    }

    public int GetHealthAsPercentage()
    {
        float healthAsFloat = healthHandler.CurrentHealth / (float) healthHandler.MaxHealth;

        return (int) (healthAsFloat * 100);
    }

    public void TakeTurn()
    {
        behaviour.UseAbility();
    }
}

public enum Relation
{
    FRIENDLY,
    UNFRIENDLY
}
