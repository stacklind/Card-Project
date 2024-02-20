using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : ICard, ITargetable
{
    private int _healingAmount = 10;
    private string _cardText = "´Heal 10 HP";
    private Relation _targetRelation = Relation.FRIENDLY;
    private int _targetCount = 1;

    public int ManaCost { get; set; }
    public string CardText { get => _cardText; set => _cardText = value; }
    public Relation TargetRelation { get => _targetRelation; set => _targetRelation = value; }
    public int TargetCount { get => _targetCount; set => _targetCount = value; }

    public void Play(Character[] targets)
    {
        targets[0].GetComponent<HealthHandler>().CurrentHealth += _healingAmount;
    }
}
