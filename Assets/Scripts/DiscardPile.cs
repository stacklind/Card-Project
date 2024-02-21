using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : MonoBehaviour
{
    private List<CardObject> discards = new List<CardObject>();

    private void Awake()
    {
        GameEvents.onCardPlayed += AddCardToDiscardPile;
    }

    public void AddCardToDiscardPile(CardObject card)
    {
        discards.Add(card);
    }

    public void RemoveCardFromDiscardPile(CardObject card)
    {
        discards.Remove(card);
    }

    public CardObject[] GetDiscardPile()
    {
        return discards.ToArray();
    }
}
