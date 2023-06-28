using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard
{
    public int ManaCost { get; set; }
    public string CardText { get; set; }
    public Relation TargetRelation { get; set; }

    public abstract void Play(Character target);
}
