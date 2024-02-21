using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GUI : MonoBehaviour
{
    [SerializeField] private TargetingGUI targetingGUI;
    [SerializeField] private TMP_Text errorMessageTextComponent;
    [SerializeField] private Transform displayCardAnchor;

    private void Awake()
    {
        ErrorHandler.displayErrorMessage += DisplayError;
        GameEvents.onTargetsRequired += DisplayTargetingGUI;
        GameEvents.onTargetingComplete += HideTargetingGUI;
        GameEvents.onCardPlayed += DisplayCard;
    }

    public void DisplayCard(CardInstance card)
    {
        card.transform.position = displayCardAnchor.position;
    }

    public void DisplayTargetingGUI(TargetAquisition targetAquisition)
    {
        targetingGUI.gameObject.SetActive(true);
    }

    public void HideTargetingGUI()
    {
        GameEvents.RaiseTargetingCanceled();
        targetingGUI.gameObject.SetActive(false);
    }

    public void HideTargetingGUI(Character[] targets)
    {
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
