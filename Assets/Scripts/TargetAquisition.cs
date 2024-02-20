using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAquisition
{
    private Character[] targets;
    private int _targetsRemaining;
    private Relation _relationRequirement;

    public int TargetsRemaining 
    {
        get => _targetsRemaining; 
        private set 
        {
            _targetsRemaining = value;
            if(_targetsRemaining == 0)
            {
                GUIHandler.AquisitionComplete();
            }
        }
    }
    public Relation RelationRequirement { get => _relationRequirement; }

    public TargetAquisition(int numberOfTargets, Relation relation)
    {
        _targetsRemaining = numberOfTargets;
        targets = new Character[_targetsRemaining];
        _relationRequirement = relation;
    }

    public void AddTarget(Character target)
    {
        targets[TargetsRemaining-- - 1] = target;
    }

    public Character[] GetTargets()
    {
        return targets;
    }

    public void Cancel()
    {
        targets = new Character[0];
        TargetsRemaining = 0;
    }
}
