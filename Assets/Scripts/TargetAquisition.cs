using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAquisition
{
    private Character[] targets;
    private int targetsRemaining;
    private Relation relationRequirement;

    public TargetAquisition(int numberOfTargets, Relation relation)
    {
        targetsRemaining = numberOfTargets;
        targets = new Character[targetsRemaining];
        relationRequirement = relation;
        RegisterEvents();
    }
    
    private void RegisterEvents()
    {
        GameEvents.onCharacterClicked += IsValidTarget;
        GameEvents.onTargetingCanceled += Cancel;
        GameEvents.onGameEnd += UnregisterEvents;
    }

    private void UnregisterEvents()
    {
        GameEvents.onCharacterClicked -= IsValidTarget;
        GameEvents.onTargetingCanceled -= Cancel;
        GameEvents.onGameEnd -= UnregisterEvents;
    }

    public void IsValidTarget(Character target)
    {
        if(target.Relation == relationRequirement)
        {
            AddTarget(target);
        }
        else
        {
            ErrorHandler.ThrowError("Invalid target");
        }
    }

    private void AddTarget(Character target)
    {
        targets[targetsRemaining-- - 1] = target;
        GameEvents.RaiseTargetFound(targetsRemaining);

        if (targetsRemaining == 0)
        {
            GameEvents.RaiseTargetingComplete(targets);
            UnregisterEvents();
        }
    }

    public Character[] GetTargets()
    {
        return targets;
    }

    public void Cancel()
    {
        targets = new Character[0];
        targetsRemaining = 0;
        UnregisterEvents();
    }
}
