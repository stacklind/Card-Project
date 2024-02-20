using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro.EditorUtilities;
using UnityEngine;

public static class GUIHandler
{
    private static Transform _playedCardAnchor;
    private static TargetAquisition _targetAquisition;
    private static GUI _gui;
    public static bool AquiringTargets { get => _targetAquisition != null; }
    
    public static Transform PlayedCardAnchor
    {
        get => _playedCardAnchor;
    }

    public static TargetAquisition TargetAquisition
    {
        get => _targetAquisition;
    }

    public static void Init(Transform playedCardAnchor, GUI gui)
    {
        _playedCardAnchor = playedCardAnchor;
        _gui = gui;
    }

    public static void AquireTargets(TargetAquisition targetAquisition)
    {
        _targetAquisition = targetAquisition;
        _gui.DisplayTargetingGUI(targetAquisition);
    }

    public static void AquisitionComplete()
    {
        _targetAquisition = null;
        _gui.HideTargetingGUI();
    }

    public static void CancleTargetAquisition()
    {
        _targetAquisition?.Cancle();
    }
}
