using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] GameObject _errorMessageObject;
    private void Awake()
    {
        CardDatabase.Init();
        ErrorHandler.Init(_errorMessageObject);
    }
}
