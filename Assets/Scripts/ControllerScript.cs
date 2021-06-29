using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public RainRequest rainRequest;
    
    public GameObject panelPrefab;
    public GameObject panelOrigin;
    public GameObject middleCurtain;
    public GameObject extendedPanel;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject pageTitle;
    
    private Days[] daysArray;
    private List<RainData> rainDataList;

    private const float panelSize = 100.0f;
    private const float panelYPosition = -60.0f;

    void Start()
    {
        EventHandlerScript eventHandler = EventHandlerScript.current;

        eventHandler.onRainRequestFinish += ActivatePanels;
        eventHandler.onPanelClicked += popExtendedPanel;
        eventHandler.onCloseExtendedPanel += extendedPanelClosed;
        eventHandler.onLeftArrowClicked += moveExtendedPanelLeft;
        eventHandler.onRightArrowClicked += moveExtendedPanelRight;

        rainRequest = new RainRequest();
        StartCoroutine(rainRequest.GetRequest("https://private-4945e-weather34.apiary-proxy.com/weather34/rain"));
    }

    public void ActivatePanels()
    {
        rainDataList = RainRequest.forecast;

        daysArray = rainDataList[0].days;

        float leftMostPanelPosition = -(panelSize / 2) * (daysArray.Length - 1);
        float offset = -leftMostPanelPosition + panelSize;

        foreach(Days dayData in daysArray)
        {
            createNewPanel(dayData, calculatePosition(dayData.day, offset));
        }

    }

    private float calculatePosition(int day, float offset)
    {
        return (day * panelSize) - offset;
    }

    private void createNewPanel(Days dayData, float xPosition)
    {
        GameObject newPanel = Instantiate(panelPrefab, panelOrigin.transform);
        MenuPanel panelMenu = newPanel.GetComponent<MenuPanel>();
        panelMenu.SetDayAndPrecipitation(dayData.day, dayData.amount);
        newPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(xPosition, panelYPosition, 0);
    }

    private void popExtendedPanel(int i)
    {
        panelOrigin.SetActive(false);
        pageTitle.SetActive(false);

        middleCurtain.SetActive(true);
        extendedPanel.SetActive(true);
        leftArrow.SetActive(true);
        rightArrow.SetActive(true);

        Days clickedDay = daysArray[i - 1];
        extendedPanel.GetComponent<ExtendedPanel>().SetDayAndPrecipitation(clickedDay.day, clickedDay.amount);
    }

    private void extendedPanelClosed()
    {
        panelOrigin.SetActive(true);
        pageTitle.SetActive(true);
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
    }

    private void moveExtendedPanelRight()
    {
        int newDayNumber = extendedPanel.GetComponent<ExtendedPanel>().activeDay + 1;

        if (newDayNumber <= daysArray.Length)
        {
            Days newDay = daysArray[newDayNumber - 1];
            extendedPanel.GetComponent<ExtendedPanel>().DeleteWeatherIllustration();
            extendedPanel.GetComponent<ExtendedPanel>().SetDayAndPrecipitation(newDay.day, newDay.amount);

            if (newDayNumber == 2)
            {
                leftArrow.SetActive(true);
            }

            if (newDayNumber > daysArray.Length -1)
            {
                rightArrow.SetActive(false);
            } 
        }
    }

    private void moveExtendedPanelLeft()
    {
        int newDayNumber = extendedPanel.GetComponent<ExtendedPanel>().activeDay - 1;

        if (newDayNumber >= 0)
        {
            Days newDay = daysArray[newDayNumber - 1];
            extendedPanel.GetComponent<ExtendedPanel>().DeleteWeatherIllustration();
            extendedPanel.GetComponent<ExtendedPanel>().SetDayAndPrecipitation(newDay.day, newDay.amount);

            if (newDayNumber == daysArray.Length-1)
            {
                rightArrow.SetActive(true);
            }

            if (newDayNumber == 1)
            {
                leftArrow.SetActive(false);
            }

        }
    }
}
