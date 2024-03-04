using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : Character
{
    private bool isFirstTurn = true;

    private void Awake()
    {
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        GameEvents.onPlayerEndTurn += EndTurn;
        GameEvents.onGameEnd += UnregisterEvents;
    }

    private void UnregisterEvents()
    {
        GameEvents.onPlayerEndTurn -= EndTurn;
        GameEvents.onGameEnd -= UnregisterEvents;
    }

    public override void TakeTurn()
    {
        if (!isFirstTurn)
        {
            GameEvents.RaiseDrawCard();
            
        }
        else
        {
            isFirstTurn = false;
        }
        
        GameEvents.RaisePlayerStartTurn();
    }
}
