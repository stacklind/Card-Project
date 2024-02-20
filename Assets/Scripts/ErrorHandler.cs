using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class ErrorHandler
{
    public class DummyObject : MonoBehaviour { }

    private static readonly float ERROR_DISPLAY_TIME = 2f;
    private static TMP_Text _errorMessageTextComponent;
    private static DummyObject dummyObject;

    public static void Init(GameObject errorMessageTextComponent)
    {
        _errorMessageTextComponent = errorMessageTextComponent.GetComponent<TMP_Text>();
        _errorMessageTextComponent.text = "";
        dummyObject = new GameObject("ErrorDummyObject").AddComponent<DummyObject>();
    }

    public static void ThrowError(string errorMsg)
    {
        _errorMessageTextComponent.text = errorMsg;
        dummyObject.StartCoroutine(DisplayError());
    }

    private static IEnumerator DisplayError()
    {
        _errorMessageTextComponent.gameObject.SetActive(true);

        float i = 0f;

        while(i < ERROR_DISPLAY_TIME)
        {
            i += Time.fixedDeltaTime;
            yield return null;
        }

        _errorMessageTextComponent.gameObject.SetActive(false);
    }
}
