using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : ICard
{
    private int _healingAmount = 10;
    private string _cardText = "´Heal 10 HP";
    private Relation _targetRelation = Relation.FRIENDLY;

    public int ManaCost { get; set; }
    public string CardText { get => _cardText; set => _cardText = value; }
    public Relation TargetRelation { get => _targetRelation; set => _targetRelation = value; }

    public void Play(Character target)
    {
        target.GetComponent<HealthHandler>().CurrentHealth += _healingAmount;
    }
}
