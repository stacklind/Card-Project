using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    [SerializeField] GameObject targetingGUI;

    public void DisplayTargetingGUI(TargetAquisition targetAquisition)
    {
        targetingGUI.SetActive(true);
    }

    public void HideTargetingGUI()
    {
        GUIHandler.CancelTargetAquisition();
        targetingGUI.SetActive(false);
    }
}
