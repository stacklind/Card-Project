using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUI : MonoBehaviour
{
    [SerializeField] private TargetingGUI targetingGUI;

    public void DisplayTargetingGUI(TargetAquisition targetAquisition)
    {
        targetAquisition.targetingTextUpdate += targetingGUI.UpdateTargetingText;
        targetAquisition.targetingTextUpdate(targetAquisition.TargetsRemaining);
        targetingGUI.gameObject.SetActive(true);
    }

    public void HideTargetingGUI()
    {
        GUIHandler.CancelTargetAquisition();
        targetingGUI.gameObject.SetActive(false);
    }
}
