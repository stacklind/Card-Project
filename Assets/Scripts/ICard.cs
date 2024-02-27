using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard
{
    public int ManaCost { get; }
    public string CardText { get; }
    public Relation TargetRelation { get; }
    public DestinationType Destination { get; }

    public abstract void Play(Character[] targets);
}
