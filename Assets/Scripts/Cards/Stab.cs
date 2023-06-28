using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : ICard
{
    private int _damageAmount = 10;
    private string _cardText = "Deal 10 damage";
    private Relation _targetRelation = Relation.UNFRIENDLY;

    public int ManaCost { get; set; }
    public string CardText { get => _cardText; set => _cardText = value; }
    public Relation TargetRelation { get => _targetRelation; set => _targetRelation = value; }

    public void Play(Character target)
    {
        target.GetComponent<HealthHandler>().CurrentHealth -= _damageAmount;
    }
}
