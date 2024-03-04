using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHeal : CauseableEffect
{
    private int healAmount;

    public EHeal(int healAmount)
    {
        this.healAmount = healAmount;
    }

    public override void CauseEffect(Character[] targets)
    {
        foreach (Character target in targets)
        {
            target.Heal(healAmount);
        }
    }

    public override string ToString()
    {
        return healAmount + " healing";
    }
}
