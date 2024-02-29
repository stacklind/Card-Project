using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform charactersRoot;
    [SerializeField] private Transform characterSpawnPoint;
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private GameObject playerPrefab;

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
        NPC character = characterObject.GetComponent<NPC>();
        Behaviour behaviour = Database.GetBehaviourByID(characterID);
        character.Init(behaviour);
        GameEvents.RaiseCharacterSpawned(character);
    }

    private void CreatePlayerCharacter()
    {
        GameObject playerCharacterObject = Instantiate(playerPrefab, charactersRoot);
        playerCharacterObject.name = "Player";
        playerCharacterObject.transform.position = -characterSpawnPoint.position;
        PC playerCharacter = playerCharacterObject.GetComponent<PC>();
        GameEvents.RaiseCharacterSpawned(playerCharacter);
    }
}
