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
        GameEvents.onHandleEffects += QueueEffectHandling;
        GameEvents.onEffectsHandled += HandleNext;
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
