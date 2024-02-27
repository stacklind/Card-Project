using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform charactersRoot;
    [SerializeField] private Transform characterSpawnPoint;
    [SerializeField] private GameObject characterPrefab;

    private void Awake()
    {
        GameEvents.onLoadPlayer += CreatePlayerCharacter;
        GameEvents.onRequestCardCreation += CreateCard;
        GameEvents.onRequestCharacterCreation += CreateCharacter;
    }

    private void CreateCard(int cardID, IDestination destination)
    {
        GameObject cardObject = Instantiate(cardPrefab);
        cardObject.SetActive(false);
        CardInstance cardInstance = cardObject.GetComponent<CardInstance>();
        cardInstance.Init(Database.GetCardByID(cardID));
        destination.AddCard(cardInstance);
    }

    private void CreateCharacter(int characterID)
    {
        GameObject characterObject = Instantiate(characterPrefab, charactersRoot);
        characterObject.transform.position = characterSpawnPoint.position;
        Character character = characterObject.GetComponent<Character>();
        Behaviour behaviour = Database.GetBehaviourByID(characterID);
        character.Init(behaviour);
        GameEvents.RaiseCharacterSpawned(character);
    }

    private void CreatePlayerCharacter()
    {
        GameObject playerCharacterObject = Instantiate(characterPrefab, charactersRoot);
        playerCharacterObject.name = "Player";
        playerCharacterObject.transform.position = -characterSpawnPoint.position;
        Character playerCharacter = playerCharacterObject.GetComponent<Character>();
        playerCharacter.Relation = Relation.FRIENDLY;
        GameEvents.RaiseCharacterSpawned(playerCharacter);
    }
}
