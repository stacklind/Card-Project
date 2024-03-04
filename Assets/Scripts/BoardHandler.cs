using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class BoardHandler
{
    EffectHandler eh;
    private Dictionary<Relation, List<Character>> characters;
    private List<Character> deadCharacters;
    private Relation currentSide;
    private int currentCharacter;

    public BoardHandler()
    {
        eh = new EffectHandler();
        characters = new Dictionary<Relation, List<Character>> ();
        deadCharacters = new List<Character> ();
        List<Character> allies = new List<Character>();
        List<Character> enemies = new List<Character>();
        
        characters.Add(Relation.FRIENDLY, allies);
        characters.Add(Relation.UNFRIENDLY, enemies);
        
        RegisterEvents();
    }


    private void RegisterEvents()
    {
        GameEvents.onCharacterSpawned += AddCharacter;
        GameEvents.onCharacterRequestTargets += SendTargetsToCharacter;
        GameEvents.onBeginNextTurn += StartNewTurn;
        GameEvents.onCharacterDoneWithTurn += CharacterTakeTurn;
        GameEvents.onCharacterDied += RemoveCharacter;
        GameEvents.onGameEnd += UnRegisterEvents;
    }

    private void UnRegisterEvents()
    {
        GameEvents.onCharacterSpawned -= AddCharacter;
        GameEvents.onCharacterRequestTargets -= SendTargetsToCharacter;
        GameEvents.onBeginNextTurn -= StartNewTurn;
        GameEvents.onCharacterDoneWithTurn -= CharacterTakeTurn;
        GameEvents.onCharacterDied -= RemoveCharacter;
        GameEvents.onGameEnd -= UnRegisterEvents;
    }

    private void AddCharacter(Character character)
    {
        characters[character.Relation].Add(character);
    }

    private void RemoveCharacter(Character character)
    {
        characters[character.Relation].Remove(character);
        
        deadCharacters.Add(character);
    }

    private void StartNewTurn(Relation side)
    {
        if (characters[side].Count == 0)
        {
            GameEvents.RaiseGameEnded();
        }
        else
        {
            currentSide = side;
            currentCharacter = 0;
            CharacterTakeTurn();
        }
    }

    private void CharacterTakeTurn()
    {
        if (characters[currentSide].Count > currentCharacter)
        {
            characters[currentSide][currentCharacter++].TakeTurn();
        }
        else
        {
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
