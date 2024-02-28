using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CauseableEffect : Effect
{
    public abstract void CauseEffect(Character[] targets);
}
