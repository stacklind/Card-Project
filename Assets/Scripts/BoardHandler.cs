using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoardHandler
{
    private static List<Character> enemies;
    private static List<Character> allies;

    public static void Init()
    {
        enemies = new List<Character>();
        allies = new List<Character>(); ;
    }

    public static void AddCharacter(Character character)
    {
        if(character.relation == Relation.UNFRIENDLY)
        {
            enemies.Add(character);
        }
        else
        {
            allies.Add(character);
        }
    }

    public static void RemoveCharacter(Character character)
    {
        if (character.relation == Relation.UNFRIENDLY)
        {
            enemies.Remove(character);
        }
        else
        {
            allies.Remove(character);
        }
    }

    public static Character[] GetAllCharacters()
    {
        Character[] allCharacters = new Character[enemies.Count + allies.Count];
        enemies.CopyTo(allCharacters, 0);
        allies.CopyTo(allCharacters, enemies.Count);

        return allCharacters;
    }

    public static Character[] GetAllCharactersWithRelation(Relation relation)
    {
        if(relation == Relation.UNFRIENDLY)
        {
            return enemies.ToArray();
        }
        else
        {
            return allies.ToArray();
        }
    }
}
