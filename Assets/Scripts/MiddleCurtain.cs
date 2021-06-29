using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiddleCurtain : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        EventHandlerScript.current.CloseExtendedPanel();
        gameObject.SetActive(false);
    }

}
