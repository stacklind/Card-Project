using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetingGUI : MonoBehaviour
{
    [SerializeField] private TMP_Text targetingText;

    public void UpdateTargetingText(int targetsRemaining)
    {
        targetingText.text = "Select " + (targetsRemaining > 1 ? targetsRemaining + " targets" : "1 target");
    }
}
