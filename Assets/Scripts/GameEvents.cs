using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void OnGameStart();
    public static event OnGameStart onGameStart;

    public delegate void OnLoadPlayer();
    public static event OnLoadPlayer onLoadPlayer;

    public delegate void OnRequestCardCreation(int cardID, IDestination destionation);
    public static event OnRequestCardCreation onRequestCardCreation;

    public delegate void OnRequestCharacterCreation(int characterID);
    public static event OnRequestCharacterCreation onRequestCharacterCreation;

    public delegate void OnCardPlayed(CardInstance card);
    public static event OnCardPlayed onCardPlayed;

    public delegate void OnDrawCard();
    public static event OnDrawCard onDrawCard;

    public delegate void OnDeckEmpty(Deck deck);
    public static event OnDeckEmpty onDeckEmpty;

    public delegate void OnMoveCardToDeck(CardInstance card);
    public static event OnMoveCardToDeck onMoveCardToDeck;

    public delegate void OnMoveCardToDiscardPile(CardInstance card);
    public static event OnMoveCardToDiscardPile onMoveCardToDiscardPile;

    public delegate void OnMoveCardToHand(CardInstance card);
    public static event OnMoveCardToHand onMoveCardToHand;

    public delegate void OnRemoveCardFromDeck(CardInstance card);
    public static event OnRemoveCardFromDeck onRemoveCardFromDeck;

    public delegate void OnRemoveCardFromDiscardPile(CardInstance card);
    public static event OnRemoveCardFromDeck onRemoveCardFromDiscardPile;

    public delegate void OnRemoveCardFromHand(CardInstance card);
    public static event OnRemoveCardFromDeck onRemoveCardFromHand;

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

    public delegate Character[] OnCharacterRequestTargets(Character character);
    public static event OnCharacterRequestTargets onCharacterRequestTargets;

    public static void RaiseGameStarted()
    {
        onGameStart?.Invoke();
    }

    public static void RaiseLoadPlayer()
    {
        onLoadPlayer?.Invoke();
    }

    public static void RaiseRequestCardCreation(int cardID, IDestination destination)
    {
        onRequestCardCreation?.Invoke(cardID, destination);
    }

    public static void RaiseRequestCharacterCreation(int characterID)
    {
        onRequestCharacterCreation?.Invoke(characterID);
    }

    public static void RaiseCardPlayed(CardInstance card)
    {
        onCardPlayed?.Invoke(card);
    }

    public static void RaiseDrawCard()
    {
        onDrawCard?.Invoke();
    }

    public static void RaiseDeckEmpty(Deck deck)
    {
        onDeckEmpty?.Invoke(deck);
    }

    public static void RaiseMoveCardToDeck(CardInstance card)
    {
        onMoveCardToDeck?.Invoke(card);
    }

    public static void RaiseMoveCardToDiscardPile(CardInstance card)
    {
        onMoveCardToDiscardPile?.Invoke(card);
    }

    public static void RaiseMoveCardToHand(CardInstance card)
    {
        onMoveCardToHand?.Invoke(card);
    }

    public static void RaiseRemoveCardFromDeck(CardInstance card)
    {
        onRemoveCardFromDeck?.Invoke(card);
    }

    public static void RaiseRemoveCardFromDiscardPile(CardInstance card)
    {
        onRemoveCardFromDiscardPile?.Invoke(card);
    }

    public static void RaiseRemoveCardFromHand(CardInstance card)
    {
        onRemoveCardFromHand?.Invoke(card);
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

    public static Character[] RaiseCharacterRequestTargets(Character character)
    {
        return onCharacterRequestTargets?.Invoke(character);
    }
}
