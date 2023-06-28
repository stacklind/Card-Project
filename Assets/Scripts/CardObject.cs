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

    private int manaCost;
    private TMP_Text cardText;
    private delegate void playCardFunction(Character target);
    private playCardFunction PlayCard;
    private Relation targetRelationRequirement;

    public void Init(ICard card)
    {
        PlayCard = card.Play;
        cardText = transform.Find("CardText").GetComponent<TextMeshPro>();
        manaCost = card.ManaCost;
        targetRelationRequirement = card.TargetRelation;

        targetLayer = LayerMask.GetMask("Target");
        cardText.text = card.CardText;
        inHand = true;
        cardHandPos = transform.position;
    }

    private void OnMouseDown()
    {
        cardHandPos = transform.position;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    private void OnMouseDrag()
    {
        Vector3 currentScreenPoint = Input.mousePosition;
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
        transform.position = currentPosition;

        if(transform.position.y > HAND_CUTOFF_POINT_Y && inHand)
        {
            inHand = false;
        }
        else if(transform.position.y <= HAND_CUTOFF_POINT_Y && !inHand)
        {
            inHand = true;
        }
    }

    private void OnMouseUp()
    {
        Collider2D target = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset, targetLayer);
        Character targetCharacter;
        
        if (!inHand && target && target.TryGetComponent<Character>(out targetCharacter) && targetCharacter.relation == targetRelationRequirement)
        {
            PlayCard?.Invoke(target.GetComponent<Character>());
            Destroy(gameObject);
        }
        else
        {
            transform.position = cardHandPos;
        }
    }

    private void OnMouseEnter()
    {
        transform.position += new Vector3(0, 0.5f, 0);
        transform.localScale += new Vector3(0.2f, 0.3f, 0);
    }

    private void OnMouseExit()
    {
        transform.position -= new Vector3(0, 0.5f, 0);
        transform.localScale -= new Vector3(0.2f, 0.3f, 0);
    }
}
