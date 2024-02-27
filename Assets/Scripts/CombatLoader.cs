using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLoader : MonoBehaviour
{
    private void Awake()
    {
        Database.Init();
    }

    private void Start()
    {
        GameEvents.RaiseLoadPlayer();
        GameEvents.RaiseRequestCharacterCreation(0);
        GameEvents.RaiseGameStarted();
    }
}
