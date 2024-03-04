using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardInstance : MonoBehaviour
{
    private static bool cardIsBeingPlayed = false;

    private readonly float HAND_CUTOFF_POINT_Y = -2;
    private Vector3 offset;
    private bool inHand;
    private Vector3 cardPositionInHand;

    private Card card;
    private int manaCost;
    private TMP_Text cardText;
    private IDestination location;

    public void Init(Card card)
    {
        this.card = card;
        cardText = transform.Find("CardText").GetComponent<TextMeshPro>();
        manaCost = card.ManaCost;
        cardText.text = card.ToString();
        inHand = true;
        UpdateCardPositionInHand();
    }
    
    public void SetLocation(IDestination destination)
    {
        location = destination;
    }

    private void OnMouseDown()
    {
        if (location.GetType() == typeof(Hand) && ((Hand)location).IsPlayerTurn && !cardIsBeingPlayed)
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
    }

    private void OnMouseDrag()
    {
        if (location.GetType() == typeof(Hand) && ((Hand)location).IsPlayerTurn && !cardIsBeingPlayed)
        {
            Vector3 currentScreenPoint = Input.mousePosition;
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
            transform.position = currentPosition;

            if (transform.position.y > HAND_CUTOFF_POINT_Y && inHand)
            {
                inHand = false;
            }
            else if (transform.position.y <= HAND_CUTOFF_POINT_Y && !inHand)
            {
                inHand = true;
            }
        }
    }

    private void OnMouseUp()
    {
        if (location.GetType() == typeof(Hand) && ((Hand)location).IsPlayerTurn && !cardIsBeingPlayed)
        {
            if (!inHand)
            {
                cardIsBeingPlayed = true;
                GameEvents.RaiseCardPlayed(this);
                SetupEventListeners();
                card.Play();
                
            }
            else
            {
                ReturnCardToHand();
            }
        }
    }

    private void OnMouseEnter()
    {
        if (inHand)
        {
            transform.position = cardPositionInHand + new Vector3(0, 2f, -1f);
        }
    }

    private void OnMouseExit()
    {
        if (inHand)
        {
            transform.position = cardPositionInHand;
            ResetCardSize();
        }
    }

    private void IncreaseCardSize()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    private void ResetCardSize()
    {
        transform.localScale = Vector3.one;
    }

    public void UpdateCardPositionInHand()
    {
        cardPositionInHand = transform.position;
    }

    public void SetInHand()
    {
        inHand = true;
    }

    private void ReturnCardToHand()
    {
        transform.position = cardPositionInHand;
        inHand = true;
        ResetCardSize();
    }

    private void CancelPlay()
    {
        cardIsBeingPlayed = false;
        ClearEventListeners();
        ReturnCardToHand();
    }

    private void PlayCard(Character[] targets)
    {
        cardIsBeingPlayed = false;
        ResetCardSize();
        ClearEventListeners();
        location.RemoveCard(this);
        switch (card.DestinationType)
        {
            case DestinationType.DECK:
                GameEvents.RaiseMoveCardToDeck(this);
                break;
            case DestinationType.HAND:
                GameEvents.RaiseMoveCardToHand(this);
                break;
            case DestinationType.DISCARD:
                GameEvents.RaiseMoveCardToDiscardPile(this);
                break;
        }
        
    }

    private void SetupEventListeners()
    {
        GameEvents.onTargetingComplete += PlayCard;
        GameEvents.onTargetingCanceled += CancelPlay;
    }
    private void ClearEventListeners()
    {
        GameEvents.onTargetingComplete -= PlayCard;
        GameEvents.onTargetingCanceled -= CancelPlay;
    }
}
