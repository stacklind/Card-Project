using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] GameObject _errorMessageObject;
    [SerializeField] Transform playedCardAnchor;
    [SerializeField] GUI gui;

    private void Awake()
    {
        CardDatabase.Init();
        ErrorHandler.Init(gui);
        GUIHandler.Init(playedCardAnchor, gui);
        BoardHandler.Init();
    }
}
