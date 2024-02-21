using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : MonoBehaviour
{
    private List<int> discards = new List<int>();

    public void AddCardToDiscardPile(int cardID)
    {
        discards.Add(cardID);
    }

    public void RemoveCardFromDiscardPile(int cardID)
    {
        discards.Remove(cardID);
    }

    public int[] GetDiscardPile()
    {
        return discards.ToArray();
    }
}
