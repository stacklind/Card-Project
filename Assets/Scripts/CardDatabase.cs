using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase
{
    private static List<ICard> cards;
    public static void Init()
    {
        cards = new List<ICard>
        {
            new Stab(),              // ID 0
            new HealingPotion()     // ID 1
        };
    }

    public static ICard GetCardByID(int id)
    {
        return cards[id];
    }
}
