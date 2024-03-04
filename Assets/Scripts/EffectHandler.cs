using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHandler
{
    private List<EffectBundle> effectBundles;
    private bool isHandlingEffects;

    public EffectHandler()
    {
        effectBundles = new List<EffectBundle>();
        isHandlingEffects = false;
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        GameEvents.onHandleEffects += QueueEffectHandling;
        GameEvents.onEffectsHandled += HandleNext;
        GameEvents.onGameEnd += UnregisterEvents;
    }

    private void UnregisterEvents()
    {
        GameEvents.onHandleEffects -= QueueEffectHandling;
        GameEvents.onEffectsHandled -= HandleNext;
        GameEvents.onGameEnd -= UnregisterEvents;
    }

    public void QueueEffectHandling(EffectBundle effects)
    {
        effectBundles.Add(effects);

        if (!isHandlingEffects)
        {
            
            HandleEffects();
        }
    }

    private void HandleEffects()
    {
        isHandlingEffects = true;
        effectBundles[0].AquireTargets();
    }

    private void HandleNext()
    {
        effectBundles.RemoveAt(0);
        isHandlingEffects = false;
        if(effectBundles.Count > 0)
        {
            HandleEffects();
        }
    }
}
