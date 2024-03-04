using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBundle
{
    private List<CauseableEffect> effects;
    private int numberOfTargets;
    private Relation targetRelation;

    public int NumberOfTargets { get => numberOfTargets; set => numberOfTargets = value; }
    public Relation TargetRelation { get => targetRelation; set => targetRelation = value; }

    public EffectBundle(CauseableEffect[] effects, int numberOfTargets, Relation targetRelation)
    {
        this.effects = new List<CauseableEffect>(effects);
        this.numberOfTargets = numberOfTargets;
        this.targetRelation = targetRelation;
    }

    public void AquireTargets()
    {
        if(targetRelation == Relation.SELF)
        {
            // Request Player
        }
        TargetAquisition targetAquisition = new TargetAquisition(numberOfTargets, targetRelation);
        GameEvents.RaiseTargetsRequired(targetAquisition);
        GameEvents.onTargetingComplete += CauseEffects;
        GameEvents.onTargetingCanceled += EffectsDone;
    }

    private void CauseEffects(Character[] targets)
    {
        foreach (CauseableEffect effect in effects)
        {
            effect.CauseEffect(targets);
        }

        GameEvents.onTargetingComplete -= CauseEffects;
        EffectsDone();
    }

    private void EffectsDone()
    {
        GameEvents.onTargetingCanceled -= EffectsDone;
        GameEvents.RaiseEffectsHandled();
    }

    public override string ToString()
    {
        string text = "";

        for(int i = 0; i <  effects.Count - 1; i++)
        {
            text += effects[i].ToString() + (i == effects.Count - 2 ? " and " : ", ");
        }
        text += effects[effects.Count - 1];

        switch (targetRelation)
        {
            case Relation.ANY:
                text += " to " + numberOfTargets + (numberOfTargets > 1 ? " targets" : " target");
                break;
            case Relation.FRIENDLY:
                text += " to " + numberOfTargets + (numberOfTargets > 1 ? " allies" : " ally");
                break;
            case Relation.UNFRIENDLY:
                text += " to " + numberOfTargets + (numberOfTargets > 1 ? " enemies" : " enemy");
                break;
            case Relation.SELF:
                break;
        }

        return text;
    }
}
