using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorHandler
{
    private static readonly float ERROR_DISPLAY_TIME = 0.5f;

    public delegate void DisplayErrorMessage(string errorMessage, float duration);
    public static DisplayErrorMessage displayErrorMessage;

    public static void ThrowError(string errorMsg)
    {
        displayErrorMessage(errorMsg, ERROR_DISPLAY_TIME);
    }
}
