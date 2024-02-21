using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class HealingPotion : ICard, ITargetable
{
    private int _healingAmount = 10;
    private string _cardText = "Heal 10 HP";
    private Relation _targetRelation = Relation.FRIENDLY;
    private int _targetCount = 1;
    private int _id;

    public int ManaCost { get; set; }
    public string CardText { get => _cardText; set => _cardText = value; }
    public Relation TargetRelation { get => _targetRelation; set => _targetRelation = value; }
    public int TargetCount { get => _targetCount; set => _targetCount = value; }
    public int Id { get => _id; }

    public void Play(Character[] targets)
    {
        targets[0].GetComponent<HealthHandler>().CurrentHealth += _healingAmount;
    }
}
