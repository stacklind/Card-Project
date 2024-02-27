using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WolfBite : Ability
{
    private int damage = 10;

    public override bool HasValidTargets(Character[] targets)
    {
        return targets.Length > 0;
    }

    public override void Use(Character[] targets)
    {
        targets[0].Damage(damage);
    }
}
