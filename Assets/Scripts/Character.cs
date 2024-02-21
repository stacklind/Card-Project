using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] HealthHandler healthHandler;

    public Relation relation;

    private void Awake()
    {
        GameEvents.RaiseCharacterSpawned(this);
    }

    private void OnMouseDown()
    {
        GameEvents.RaiseCharacterClicked(this);
    }
}

public enum Relation
{
    ANY,
    FRIENDLY,
    UNFRIENDLY
}
