using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    private Behaviour behaviour;

    public void Init(Behaviour behaviour)
    {
        this.behaviour = behaviour;
        behaviour.Init(this);
    }

    public int GetHealthAsPercentage()
    {
        float healthAsFloat = healthHandler.CurrentHealth / (float)healthHandler.MaxHealth;

        return (int)(healthAsFloat * 100);
    }

    public override void TakeTurn()
    {
        behaviour.UseAbility();
        GameEvents.RaiseCharacterDoneWithTurn();
    }
}
