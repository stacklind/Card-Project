using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatLoader : MonoBehaviour
{
    BoardHandler bh;
    private void Awake()
    {
        bh = new BoardHandler();
        Database.Init();
        RegisterEvents();
    }

    private void Start()
    {
        GameEvents.RaiseLoadPlayer();
        GameEvents.RaiseRequestCharacterCreation(0);
        GameEvents.RaiseGameStarted();
        GameEvents.RaiseBeginNextTurn(Relation.FRIENDLY);
    }

    private void RegisterEvents()
    {
        GameEvents.onGameEnd += TempEndGame;
        GameEvents.onGameEnd += UnregisterEvents;
    }

    private void UnregisterEvents()
    {
        GameEvents.onGameEnd -= TempEndGame;
    }
    private void TempEndGame()
    {
        GameEvents.onGameEnd -= UnregisterEvents;
        SceneManager.LoadScene(1);
    }
}
