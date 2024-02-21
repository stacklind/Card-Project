using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : ICard, ITargetable
{
    private int _damageAmount = 10;
    private string _cardText = "Deal 10 damage";
    private Relation _targetRelation = Relation.UNFRIENDLY;
    private int _targetCount = 1;
    private DestinationType _destination = DestinationType.DISCARD;

    public int ManaCost { get; set; }
    public string CardText { get => _cardText; }
    public Relation TargetRelation { get => _targetRelation; }
    public int TargetCount { get => _targetCount; }
    public DestinationType Destination { get => _destination; }

    public void Play(Character[] targets)
    {
        targets[0].GetComponent<HealthHandler>().CurrentHealth -= _damageAmount;
    }
}
