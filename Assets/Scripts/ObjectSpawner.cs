using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    private void Awake()
    {
        GameEvents.onRequestCardCreation += CreateCard;
    }

    private void CreateCard(int cardID, IDestination destination)
    {
        GameObject cardObject = Instantiate(cardPrefab, transform);
        CardInstance cardInstance = cardObject.GetComponent<CardInstance>();
        cardInstance.Init(CardDatabase.GetCardByID(cardID));
        destination.AddCard(cardInstance);
    }
}
