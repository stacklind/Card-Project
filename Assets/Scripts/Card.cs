using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Card
{
    public abstract int ManaCost { get; set; }
    public abstract string CardName { get; set; }
    public abstract DestinationType DestinationType { get; set; }
    public abstract List<EffectBundle> EffectBundles { get;}

    public void Play()
    {
        ParseEffects();
    }

    public void AddEffect(EffectBundle effectBundle)
    {
        EffectBundles.Add(effectBundle);
    }

    private void ParseEffects()
    {
        foreach (EffectBundle effectBundle in EffectBundles)
        {
            GameEvents.RaiseHandleEffects(effectBundle);
        }
    }

    public override string ToString()
    {
        string text = "";

        switch (DestinationType)
        {
            case DestinationType.DECK:
                text += "Return this card to your deck. ";
                break;
        }

        foreach (EffectBundle effectBundle in EffectBundles)
        {
            text += effectBundle.ToString();
        }

        return text;
    }
}
