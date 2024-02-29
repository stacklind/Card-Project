using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behaviour
{
    protected List<Ability> abilities;
    protected NPC character;
    protected State state;

    public void Init(Character character)
    {
        this.character = (NPC) character;
        abilities = new List<Ability>();
        AddAbilities();
        state = State.OFFENSIVE;
    }

    protected abstract void AddAbilities();

    protected abstract void EvaluateState();

    public abstract void UseAbility();
}

public enum State
{
    OFFENSIVE,
    DEFENSIVE,
    SUPPORTIVE
}