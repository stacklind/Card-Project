using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : Card
{
    private int manaCost = 1;
    private string cardName = "Stab";
    private DestinationType destinationType = DestinationType.DISCARD;
    private List<EffectBundle> effectBundles = new List<EffectBundle>()
    {
        new EffectBundle(new CauseableEffect[]{new Damage(10)}, 1, Relation.UNFRIENDLY)
    };

    public override int ManaCost { get => manaCost; set => manaCost = value; }
    public override string CardName { get => cardName; set => cardName = value; }
    public override DestinationType DestinationType { get => destinationType; set => destinationType = value; }
    public override List<EffectBundle> EffectBundles => effectBundles;
}
