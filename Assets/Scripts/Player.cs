using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] private Hand handHandler;
    [SerializeField] private DiscardPile discardPile;

    private void Awake()
    {
        
    }
}
