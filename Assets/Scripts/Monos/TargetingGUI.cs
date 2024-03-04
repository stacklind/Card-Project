using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetingGUI : MonoBehaviour
{
    [SerializeField] private TMP_Text targetingText;

    private void Awake()
    {
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        GameEvents.onTargetFound += UpdateTargetingText;
        GameEvents.onGameEnd += UnregisterEvents;
    }

    private void UnregisterEvents()
    {
        GameEvents.onTargetFound -= UpdateTargetingText;
        GameEvents.onGameEnd -= UnregisterEvents;
    }

    public void UpdateTargetingText(int targetsRemaining)
    {
        targetingText.text = "Select " + (targetsRemaining > 1 ? targetsRemaining + " targets" : "1 target");
    }
}
