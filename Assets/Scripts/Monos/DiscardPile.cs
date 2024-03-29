using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : MonoBehaviour, IDestination
{
    private List<CardInstance> discards = new List<CardInstance>();

    private void Awake()
    {
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        GameEvents.onDeckEmpty += ShuffleDiscardPileIntoDeck;
        GameEvents.onMoveCardToDiscardPile += AddCard;
        GameEvents.onGameEnd += UnregisterEvents;
    }

    private void UnregisterEvents()
    {
        GameEvents.onDeckEmpty -= ShuffleDiscardPileIntoDeck;
        GameEvents.onMoveCardToDiscardPile -= AddCard;
        GameEvents.onGameEnd -= UnregisterEvents;
    }

    public void AddCard(CardInstance card)
    {
        discards.Add(card);
        card.SetLocation(this);
        card.transform.SetParent(transform, false);
        card.gameObject.SetActive(false);
    }

    public void RemoveCard(CardInstance card)
    {
        discards.Remove(card);
    }

    private void ShuffleDiscardPileIntoDeck(Deck deck)
    {
        foreach(CardInstance card in discards)
        {
            deck.AddCard(card);
            
        }
        discards.Clear();
    }

    public CardInstance[] GetDiscardPile()
    {
        return discards.ToArray();
    }
}
