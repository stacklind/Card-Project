using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : CauseableEffect
{
    private int healAmount;

    public Heal(int healAmount)
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
