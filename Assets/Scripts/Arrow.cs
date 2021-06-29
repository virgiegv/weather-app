using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Arrow : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
    , IPointerClickHandler
{
    public bool isLeftArrow;

    private Vector3 sizedUp = new Vector3(1.05f, 1.05f, 1f);
    private Vector3 normalSize = new Vector3(1f, 1f, 1f);

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isLeftArrow)
        {
            EventHandlerScript.current.LeftArrowClicked();
        } else
        {
            EventHandlerScript.current.RightArrowClicked();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = sizedUp;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = normalSize;
    }
}
