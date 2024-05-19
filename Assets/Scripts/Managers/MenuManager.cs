using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private void OnEnable()
    {
        PanelEvents.OnPanelManagerInitialized += ShowMainScreen;
    }

    private void OnDisable()
    {
        PanelEvents.OnPanelManagerInitialized -= ShowMainScreen;
    }

    private void ShowMainScreen()
    {
        PanelManager.Instance.ShowPanel("MainScreen");
        FindObjectOfType<Audiomanager>().Play("Main theme");
    }
}
