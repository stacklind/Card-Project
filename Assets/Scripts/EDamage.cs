using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDamage : CauseableEffect
{
    private int damage;

    public EDamage(int damage)
    {
        this.damage = damage;
    }

    public override void CauseEffect(Character[] targets)
    {
        foreach(Character target in targets)
        {
            target.Damage(damage);
        }
    }

    public override string ToString()
    {
        return damage + " damage";
    }
}
