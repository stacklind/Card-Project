using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : CauseableEffect
{
    private int damage;

    public Damage(int damage)
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
