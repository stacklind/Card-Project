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
    private int numberOfTargets;

    private int manaCost;
    private TMP_Text cardText;
    private delegate void PlayCardFunction(Character[] targets);
    private PlayCardFunction playCard;
    private Relation targetRelationRequirement;
    private DestinationType destinationType;
    private IDestination location;

    public void Init(ICard card)
    {
        playCard = card.Play;
        cardText = transform.Find("CardText").GetComponent<TextMeshPro>();
        manaCost = card.ManaCost;
        targetRelationRequirement = card.TargetRelation;
        numberOfTargets = card is IArea ? 0 : (card as ITargetable).TargetCount;
        cardText.text = card.CardText;
        inHand = true;
        destinationType = card.Destination;
        UpdateCardPositionInHand();
    }
    
    public void SetLocation(IDestination destination)
    {
        location = destination;
    }

    private void OnMouseDown()
    {
        if (!cardIsBeingPlayed)
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
    }

    private void OnMouseDrag()
    {
        if (!cardIsBeingPlayed)
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
        if (!cardIsBeingPlayed)
        {
            if (!inHand)
            {
                cardIsBeingPlayed = true;
                GameEvents.RaiseCardPlayed(this);
                TargetAquisition targetAquisition = new TargetAquisition(numberOfTargets, targetRelationRequirement);
                SetupEventListeners();
                GameEvents.RaiseTargetsRequired(targetAquisition);
                
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
            transform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
    }

    private void OnMouseExit()
    {
        if (inHand)
        {
            transform.position = cardPositionInHand;
            transform.localScale = Vector3.one;
        }
    }

    public void UpdateCardPositionInHand()
    {
        cardPositionInHand = transform.position;
    }

    private void ReturnCardToHand()
    {
        transform.position = cardPositionInHand;
        inHand = true;
        transform.localScale = Vector3.one;
    }

    private void CancelPlay()
    {
        cardIsBeingPlayed = false;
        ClearEventListeners();
        ReturnCardToHand();
    }

    private void PlayCard(Character[] targets)
    {

        playCard?.Invoke(targets);
        cardIsBeingPlayed = false;
        ClearEventListeners();
        location.RemoveCard(this);
        switch (destinationType)
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
