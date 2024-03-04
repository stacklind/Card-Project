using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWolf : Behaviour
{
    public override void UseAbility()
    {
        EvaluateState();
        if(state == State.OFFENSIVE)
        {
            Character[] targets = GameEvents.RaiseCharacterRequestTargets(character);

            if (abilities[0].HasValidTargets(targets))
            {
                abilities[0].Use(targets);
            }
        }
    }

    protected override void AddAbilities()
    {
        abilities.Add(Database.GetAbilityByID(0));
    }

    protected override void EvaluateState()
    {
        if(character.GetHealthAsPercentage() > 0)
        {
            state = State.OFFENSIVE;
        }
    }
}
