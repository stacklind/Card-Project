using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardObject : MonoBehaviour
{
    private LayerMask targetLayer;

    private readonly float HAND_CUTOFF_POINT_Y = -2;
    private Vector3 offset;
    private bool inHand;
    private Vector3 cardHandPos;
    private int numberOfTargets;

    private int manaCost;
    private TMP_Text cardText;
    private delegate void playCardFunction(Character[] targets);
    private playCardFunction PlayCard;
    private Relation targetRelationRequirement;

    private HandHandler hand;

    public void Init(ICard card)
    {
        PlayCard = card.Play;
        cardText = transform.Find("CardText").GetComponent<TextMeshPro>();
        manaCost = card.ManaCost;
        targetRelationRequirement = card.TargetRelation;
        numberOfTargets = card is IArea ? 0 : (card as ITargetable).TargetCount;

        targetLayer = LayerMask.GetMask("Target");
        cardText.text = card.CardText;
        inHand = true;
        cardHandPos = transform.position;

        hand = GetComponentInParent<HandHandler>();
    }

    private void OnMouseDown()
    {
        if (!hand.cardIsBeingPlayed)
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
    }

    private void OnMouseDrag()
    {
        if (!hand.cardIsBeingPlayed)
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
        if (!hand.cardIsBeingPlayed)
        {
            if (!inHand)
            {
                transform.position = GUIHandler.PlayedCardAnchor.position;
                hand.cardIsBeingPlayed = true;

                StartCoroutine(RecieveTargetsAndPlay());
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
            transform.position += new Vector3(0, 0.5f, 0);
            transform.localScale += new Vector3(0.2f, 0.3f, 0);
        }
    }

    private void OnMouseExit()
    {
        if (inHand)
        {
            transform.position -= new Vector3(0, 0.5f, 0);
            transform.localScale -= new Vector3(0.2f, 0.3f, 0);
        }
    }

    private void ReturnCardToHand()
    {
        transform.position = cardHandPos;
    }

    private void CancelPlay()
    {
        hand.cardIsBeingPlayed = false;
        ReturnCardToHand();
    }

    private IEnumerator RecieveTargetsAndPlay()
    {
        Character[] targetCharacters;

        if (numberOfTargets == 0)
        {
            targetCharacters = BoardHandler.GetAllCharactersWithRelation(targetRelationRequirement);
        }
        else
        {
            TargetAquisition targetAquisition = new TargetAquisition(numberOfTargets, targetRelationRequirement);
            GUIHandler.AquireTargets(targetAquisition);

            while (targetAquisition.TargetsRemaining > 0)
            {
                yield return null;
            }

            targetCharacters = targetAquisition.GetTargets();
        }

        if (targetCharacters.Length > 0)
        {
            PlayCard?.Invoke(targetCharacters);
            hand.cardIsBeingPlayed = false;
            Destroy(gameObject);
        }
        else
        {
            CancelPlay();
        }
    }
}
