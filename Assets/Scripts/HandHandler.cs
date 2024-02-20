using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHandler : MonoBehaviour
{
    private float CARD_POS_INCRIMENT = 2.2f;
    private int HAND_MAX_SIZE = 7;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private List<int> deck;

    private List<GameObject> hand = new List<GameObject>();
    [HideInInspector] public bool cardIsBeingPlayed = false;

    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            DrawCard();
        }
    }

    public void DrawCard()
    {
        int handSize = hand.Count;
        int cardToDraw = Random.Range(0, deck.Count - 1);

        GameObject card = Instantiate(cardPrefab, transform);
        hand.Add(card);

        if(handSize > 0)
        {
            ReorganizeHand();
        }
        else
        {
            card.transform.localPosition = new Vector3(0, 0, 0);
        }

        card.GetComponent<CardObject>().Init(CardDatabase.GetCardByID(deck[cardToDraw]));
        deck.RemoveAt(cardToDraw);
    }

    public void RemoveCardFromHand(GameObject card)
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
            hand[i].GetComponent<CardObject>().UpdateCardPositionInHand();
        }
    }
}
