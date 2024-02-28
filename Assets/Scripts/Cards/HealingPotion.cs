using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class HealingPotion : Card
{
    private int manaCost = 1;
    private string cardName = "Healing Potion";
    private DestinationType destinationType = DestinationType.DISCARD;
    private List<EffectBundle> effectBundles = new List<EffectBundle>()
    {
        new EffectBundle(new CauseableEffect[]{new Heal(10)}, 1, Relation.FRIENDLY)
    };
    public override int ManaCost { get => manaCost; set => manaCost = value; }
    public override string CardName { get => cardName; set => cardName = value; }
    public override DestinationType DestinationType { get => destinationType; set => destinationType = value; }

    public override List<EffectBundle> EffectBundles => effectBundles;
}
