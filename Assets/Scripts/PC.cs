using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : Character
{
    private bool isFirstTurn = true;

    private void Awake()
    {
        GameEvents.onTogglePlayerTurn += EndTurn;
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
        
        GameEvents.RaiseTogglePlayerTurn(true);
    }

    private void EndTurn(bool isStartOfTurn)
    {
        if (!isStartOfTurn)
        {
            GameEvents.RaiseCharacterDoneWithTurn();
        }
    }
}
