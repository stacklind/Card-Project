using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase
{
    private static List<ICard> cards;
    public static void Init()
    {
        cards = new List<ICard>();
        cards.Add(new Stab());              // ID 0
        cards.Add(new HealingPotion());     // ID 1
    }

    public static ICard GetCardByID(int id)
    {
        return cards[id];
    }
}
