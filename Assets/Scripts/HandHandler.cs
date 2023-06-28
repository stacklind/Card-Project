using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHandler : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    
    private void Start()
    {
        GameObject card = Instantiate(cardPrefab, transform);
        card.transform.localPosition = new Vector3(-1.5f, 0, 0);
        card.GetComponent<CardObject>().Init(CardDatabase.GetCardByID(0));

        card = Instantiate(cardPrefab, transform);
        card.transform.localPosition = new Vector3(1.5f, 0, 0);
        card.GetComponent<CardObject>().Init(CardDatabase.GetCardByID(1));
    }

    public void DrawCard()
    {

    }
}
