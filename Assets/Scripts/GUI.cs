using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUI : MonoBehaviour
{
    [SerializeField] private TargetingGUI targetingGUI;
    [SerializeField] private TMP_Text errorMessageTextComponent;

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
    
    public void DisplayError(string errorText, float errorDisplayTime)
    {
        StartCoroutine(DisplayErrorCoroutine(errorText, errorDisplayTime));
    }

    private IEnumerator DisplayErrorCoroutine(string errorText, float errorDisplayTime)
    {
        errorMessageTextComponent.text = errorText;
        errorMessageTextComponent.gameObject.SetActive(true);

        float i = 0f;

        while (i < errorDisplayTime)
        {
            i += Time.deltaTime;
            yield return null;
        }

        errorMessageTextComponent.gameObject.SetActive(false);
    }
}
