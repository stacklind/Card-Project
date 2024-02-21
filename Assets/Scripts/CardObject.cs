using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardObject : MonoBehaviour
{
    private static bool cardIsBeingPlayed = false;
    private LayerMask targetLayer;

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

    public void Init(ICard card)
    {
        playCard = card.Play;
        cardText = transform.Find("CardText").GetComponent<TextMeshPro>();
        manaCost = card.ManaCost;
        targetRelationRequirement = card.TargetRelation;
        numberOfTargets = card is IArea ? 0 : (card as ITargetable).TargetCount;

        targetLayer = LayerMask.GetMask("Target");
        cardText.text = card.CardText;
        inHand = true;
        UpdateCardPositionInHand();
    }

    private void OnMouseDown()
    {
        Debug.Log("MouseDown");
        if (!cardIsBeingPlayed)
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Debug.Log("Offset: " + offset);
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
                TargetAquisition targetAquisition = new TargetAquisition(numberOfTargets, targetRelationRequirement);
                GameEvents.RaiseTargetsRequired(targetAquisition);
                GameEvents.RaiseCardPlayed(this);
                SetupEventListeners();
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
        GameEvents.RaiseCardResolved(this);
        gameObject.SetActive(false);
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
