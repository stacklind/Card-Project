using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLoader : MonoBehaviour
{
    BoardHandler bh;
    private void Awake()
    {
        bh = new BoardHandler();
        Database.Init();
    }

    private void Start()
    {
        GameEvents.RaiseLoadPlayer();
        GameEvents.RaiseRequestCharacterCreation(0);
        GameEvents.RaiseGameStarted();
        GameEvents.RaiseBeginNextTurn(Relation.FRIENDLY);
    }
}
