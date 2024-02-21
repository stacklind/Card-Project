using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHandler : MonoBehaviour
{
    private List<Character> enemies;
    private List<Character> allies;

    public void Awake()
    {
        enemies = new List<Character>();
        allies = new List<Character>();
        GameEvents.onCharacterSpawned += AddCharacter;
    }

    private void AddCharacter(Character character)
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

    private void RemoveCharacter(Character character)
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
}
