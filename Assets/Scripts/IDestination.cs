using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestination
{
    public abstract void AddCard(CardInstance card);

    public abstract void RemoveCard(CardInstance card);
}

public enum DestinationType
{
    DECK,
    DISCARD,
    HAND
}