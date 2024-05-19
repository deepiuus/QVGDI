using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PanelEvents
{
    public delegate void PanelManagerInitializedHandler();
    public static event PanelManagerInitializedHandler OnPanelManagerInitialized;
    public static event Action OnWheelScreenRequested;

    public static void RequestWheelScreen()
    {
        OnWheelScreenRequested?.Invoke();
    }

    public static void RaiseOnPanelManagerInitialized()
    {
        OnPanelManagerInitialized?.Invoke();
    }
}
