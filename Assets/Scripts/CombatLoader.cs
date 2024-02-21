using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLoader : MonoBehaviour
{
    private void Awake()
    {
        CardDatabase.Init();
    }

    private void Start()
    {
        GameEvents.RaiseGameStarted();
    }
}
