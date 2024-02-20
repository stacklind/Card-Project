using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class ErrorHandler
{
    private static readonly float ERROR_DISPLAY_TIME = 0.5f;
    private delegate void DisplayErrorMessage(string errorMessage, float duration);
    private static DisplayErrorMessage displayErrorMessage;

    public static void Init(GUI gui)
    {
        displayErrorMessage += gui.DisplayError;

    }

    public static void ThrowError(string errorMsg)
    {
        displayErrorMessage(errorMsg, ERROR_DISPLAY_TIME);
    }
}
