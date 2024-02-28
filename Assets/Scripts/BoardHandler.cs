using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHandler : MonoBehaviour
{
    EffectHandler eh;
    private List<Character> enemies;
    private List<Character> allies;

    public void Awake()
    {
        eh = new EffectHandler();
        enemies = new List<Character>();
        allies = new List<Character>();
        
        GameEvents.onCharacterSpawned += AddCharacter;
        GameEvents.onCharacterRequestTargets += SendTargetsToCharacter;
    }

    private void AddCharacter(Character character)
    {
        if(character.Relation == Relation.UNFRIENDLY)
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
        if (character.Relation == Relation.UNFRIENDLY)
        {
            enemies.Remove(character);
        }
        else
        {
            allies.Remove(character);
        }
    }

    public Character[] SendTargetsToCharacter(Character character)
    {
        if (character.Relation == Relation.UNFRIENDLY)
        {
            return allies.ToArray();
        }
        else
        {
            
            return enemies.ToArray();
        }
    }

    public void TempEnemyTurn()
    {
        enemies[0].TakeTurn();
    }
}
