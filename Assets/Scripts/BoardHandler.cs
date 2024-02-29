using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class BoardHandler
{
    EffectHandler eh;
    private Dictionary<Relation, List<Character>> characters;
    
    private Relation currentSide;
    private int currentCharacter;

    public BoardHandler()
    {
        eh = new EffectHandler();
        characters = new Dictionary<Relation, List<Character>> ();
        List<Character> allies = new List<Character>();
        List<Character> enemies = new List<Character>();
        
        characters.Add(Relation.FRIENDLY, allies);
        characters.Add(Relation.UNFRIENDLY, enemies);
        
        GameEvents.onCharacterSpawned += AddCharacter;
        GameEvents.onCharacterRequestTargets += SendTargetsToCharacter;
        GameEvents.onBeginNextTurn += StartNewTurn;
        GameEvents.onCharacterDoneWithTurn += CharacterTakeTurn;
    }

    private void AddCharacter(Character character)
    {
        characters[character.Relation].Add(character);
        Debug.Log("Added chararacter to " + character.Relation + " new size is " + characters[character.Relation].Count);
    }

    private void RemoveCharacter(Character character)
    {
        characters[character.Relation].Remove(character);
    }

    private void StartNewTurn(Relation side)
    {
        Debug.Log("New turn: " + side);
        currentSide = side;
        currentCharacter = 0;
        CharacterTakeTurn();
    }

    private void CharacterTakeTurn()
    {
        Debug.Log("Character nr " + currentCharacter + " should take its turn");
        if (characters[currentSide].Count > currentCharacter)
        {
            characters[currentSide][currentCharacter++].TakeTurn();
        }
        else
        {
            Debug.Log("There arent anymore characters on this side (" + characters[currentSide].Count + ") swap sides");
            GameEvents.RaiseBeginNextTurn(currentSide == Relation.FRIENDLY ? Relation.UNFRIENDLY : Relation.FRIENDLY);
        }
    }

    public Character[] SendTargetsToCharacter(Character character)
    {
        if (character.Relation == Relation.UNFRIENDLY)
        {
            return characters[Relation.FRIENDLY].ToArray();
        }
        else
        {
            
            return characters[Relation.FRIENDLY].ToArray();
        }
    }
}
