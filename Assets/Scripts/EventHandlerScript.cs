using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandlerScript : MonoBehaviour
{
    public static EventHandlerScript current;
    private void Awake()
    {
        current = this;
    }

    public event Action onRainRequestFinish;
    public void RainRequestFinished()
    {
        if(onRainRequestFinish != null)
        {
            onRainRequestFinish();
        }
    }

    public event Action<int> onPanelClicked;
    public void PanelClicked(int i)
    {
        if (onPanelClicked != null)
        {
            onPanelClicked(i);
        }
    }

    public event Action onCloseExtendedPanel;
    public void CloseExtendedPanel()
    {
        if (onCloseExtendedPanel != null)
        {
            onCloseExtendedPanel();
        }
    }

    public event Action onLeftArrowClicked;
    public void LeftArrowClicked()
    {
        if (onLeftArrowClicked != null)
        {
            onLeftArrowClicked();
        }
    }

    public event Action onRightArrowClicked;
    public void RightArrowClicked()
    {
        if (onRightArrowClicked != null)
        {
            onRightArrowClicked();
        }
    }
}
