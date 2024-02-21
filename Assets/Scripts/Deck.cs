using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Deck : MonoBehaviour, IDestination
{
    [SerializeField] private List<int> startingCards;
    private List<CardInstance> cards;

    private void Awake()
    {
        cards = new List<CardInstance>();
        GameEvents.onMoveCardToDeck += AddCard;
        GameEvents.onDrawCard += DrawCard;
        GameEvents.onGameStart += PrepareStartingCards;
    }

    private void PrepareStartingCards()
    {
        foreach (int card in startingCards)
        {
            GameEvents.RaiseRequestCardCreation(card, this);
        }

        for(int i = 0; i < 5; i++)
        {
            GameEvents.RaiseDrawCard();
        }
    }

    public void AddCard(CardInstance card)
    {
        cards.Add(card);
        card.SetLocation(this);
        card.gameObject.transform.SetParent(transform, false);
    }

    public void RemoveCard(CardInstance card)
    {
        cards.Remove(card);
    }

    private void DrawCard()
    {
        if (cards.Count == 0)
        {
            GameEvents.RaiseDeckEmpty(this);
        }

        int cardToDraw = Random.Range(0, cards.Count - 1);
        CardInstance card = cards[cardToDraw];
        RemoveCard(card);
        GameEvents.RaiseMoveCardToHand(card);
    }
}
