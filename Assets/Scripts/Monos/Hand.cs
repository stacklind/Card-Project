using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Hand : MonoBehaviour, IDestination
{
    private float CARD_POS_INCRIMENT = 2.2f;
    private int HAND_MAX_SIZE = 7;
    private bool isPlayerTurn = false;
    private List<CardInstance> hand = new List<CardInstance>();

    public bool IsPlayerTurn { get => isPlayerTurn; }

    private void Awake()
    {
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        GameEvents.onMoveCardToHand += AddCard;
        GameEvents.onPlayerStartTurn += ToggleIsPlayerTurn;
        GameEvents.onPlayerEndTurn += ToggleIsPlayerTurn;
        GameEvents.onGameEnd += UnregisterEvents;
    }

    private void UnregisterEvents()
    {
        GameEvents.onMoveCardToHand -= AddCard;
        GameEvents.onPlayerStartTurn -= ToggleIsPlayerTurn;
        GameEvents.onPlayerEndTurn -= ToggleIsPlayerTurn;
        GameEvents.onGameEnd -= UnregisterEvents;
    }

    private void ToggleIsPlayerTurn()
    {
        isPlayerTurn = !isPlayerTurn;
    }

    public void AddCard(CardInstance card)
    {
        int handSize = hand.Count;
        hand.Add(card);
        card.SetInHand();
        card.transform.SetParent(transform);
        card.SetLocation(this);

        if (handSize > 0)
        {
            ReorganizeHand();
        }
        else
        {
            card.transform.localPosition = new Vector3(0, 0, 0);
            
        }
        card.gameObject.SetActive(true);
    }

    public void RemoveCard(CardInstance card)
    {
        hand.Remove(card);
        ReorganizeHand();
    }

    private void ReorganizeHand()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            float xPos = -CARD_POS_INCRIMENT / 2f * (hand.Count - 1) + (i * CARD_POS_INCRIMENT);
            float yPos = (hand.Count % 2 == 0 ? Mathf.Min(Mathf.Abs(hand.Count / 2 - 1 - i), Mathf.Abs(hand.Count / 2 - i)) : Mathf.Abs(hand.Count / 2 - i)) * -0.1f;
            float zPos = -i / 10f;
            hand[i].transform.localPosition = new Vector3(xPos, yPos, zPos);
            hand[i].GetComponent<CardInstance>().UpdateCardPositionInHand();
        }
    }
}
