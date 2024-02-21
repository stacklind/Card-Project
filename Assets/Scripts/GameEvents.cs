using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void OnGameStart();
    public static event OnGameStart onGameStart;

    public delegate void OnCardPlayed(CardObject card);
    public static event OnCardPlayed onCardPlayed;

    public delegate void OnCardResolved(CardObject card);
    public static event OnCardResolved onCardResolved;

    public delegate void OnCardDraw();
    public static event OnCardDraw onCardDraw;

    public delegate void OnDamageTaken(Character target, int damage);
    public static event OnDamageTaken onDamageTaken;

    public delegate void OnCharacterSpawned(Character character);
    public static event OnCharacterSpawned onCharacterSpawned;

    public delegate void OnTargetsRequired(TargetAquisition targetAquisition);
    public static event OnTargetsRequired onTargetsRequired;

    public delegate void OnTargetFound(int targetsRemaining);
    public static event OnTargetFound onTargetFound;

    public delegate void OnTargetingComplete(Character[] targets);
    public static event OnTargetingComplete onTargetingComplete;

    public delegate void OnTargetingCanceled();
    public static event OnTargetingCanceled onTargetingCanceled;

    public delegate void OnCharacterClicked(Character character);
    public static event OnCharacterClicked onCharacterClicked;

    public static void RaiseGameStarted()
    {
        onGameStart?.Invoke();
    }

    public static void RaiseCardPlayed(CardObject card)
    {
        onCardPlayed?.Invoke(card);
    }

    public static void RaiseCardResolved(CardObject card)
    {
        onCardResolved?.Invoke(card);
    }

    public static void RaiseCardDraw()
    {
        onCardDraw?.Invoke();
    }

    public static void RaiseDamageTaken(Character target, int damage)
    {
        onDamageTaken?.Invoke(target, damage);
    }

    public static void RaiseCharacterSpawned(Character character)
    {
        onCharacterSpawned?.Invoke(character);
    }

    public static void RaiseTargetsRequired(TargetAquisition targetAquisition)
    {
        onTargetsRequired.Invoke(targetAquisition);
    }

    public static void RaiseTargetFound(int targetsRemaining)
    {
        onTargetFound?.Invoke(targetsRemaining);
    }

    public static void RaiseTargetingComplete(Character[] targets)
    {
        onTargetingComplete?.Invoke(targets);
    }

    public static void RaiseTargetingCanceled()
    {
        onTargetingCanceled?.Invoke();
    }

    public static void RaiseCharacterClicked(Character character)
    {
        onCharacterClicked?.Invoke(character);
    }
}
