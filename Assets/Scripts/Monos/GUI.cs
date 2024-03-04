using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GUI : MonoBehaviour
{
    [SerializeField] private GameObject targetingGUI;
    [SerializeField] private TMP_Text errorMessageTextComponent;
    [SerializeField] private Transform displayCardAnchor;
    [SerializeField] private GameObject endTurnButton;

    private void Awake()
    {
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        ErrorHandler.displayErrorMessage += DisplayError;
        GameEvents.onTargetsRequired += DisplayTargetingGUI;
        GameEvents.onTargetingComplete += HideTargetingGUI;
        GameEvents.onCardPlayed += DisplayCard;
        GameEvents.onPlayerStartTurn += ShowPlayerEndTurnButton;
        GameEvents.onGameEnd += UnregisterEvents;
    }

    private void UnregisterEvents()
    {
        ErrorHandler.displayErrorMessage -= DisplayError;
        GameEvents.onTargetsRequired -= DisplayTargetingGUI;
        GameEvents.onTargetingComplete -= HideTargetingGUI;
        GameEvents.onCardPlayed -= DisplayCard;
        GameEvents.onPlayerStartTurn -= ShowPlayerEndTurnButton;
        GameEvents.onGameEnd -= UnregisterEvents;
    }

    private void DisplayCard(CardInstance card)
    {
        card.transform.position = displayCardAnchor.position;
    }

    private void DisplayTargetingGUI(TargetAquisition targetAquisition)
    {
        targetingGUI.SetActive(true);
    }

    public void HideTargetingGUI()
    {
        GameEvents.RaiseTargetingCanceled();
        targetingGUI.SetActive(false);
    }

    private void HideTargetingGUI(Character[] targets)
    {
        targetingGUI.SetActive(false);
    }

    private void ShowPlayerEndTurnButton()
    {
        endTurnButton.SetActive(true);
    }

    public void EndPlayerTurn()
    {
        endTurnButton.SetActive(false);
        GameEvents.RaisePlayerEndTurn();
    }

    private void DisplayError(string errorText, float errorDisplayTime)
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
