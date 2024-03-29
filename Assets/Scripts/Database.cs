using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database
{
    private static List<Card> cards;
    private static List<Ability> abilities;
    private static List<Behaviour> behaviours;

    public static void Init()
    {
        cards = new List<Card>
        {
            new CStab(),                     // ID 0
            new CHealingPotion()             // ID 1
        };

        abilities = new List<Ability>
        {
            new AWolfBite()                  // ID 0
        };

        behaviours = new List<Behaviour>
        {
            new BWolf()                      // ID 0
        };
    }

    public static Card GetCardByID(int id)
    {
        return cards[id];
    }

    public static Ability GetAbilityByID(int id)
    {
        return abilities[id];
    }

    public static Behaviour GetBehaviourByID(int id)
    {
        return behaviours[id];
    }
}
