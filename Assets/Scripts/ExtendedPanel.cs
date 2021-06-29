using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExtendedPanel : MonoBehaviour
{
    public int activeDay;
    private GameObject weatherIllustration;

    public GameObject sunnyIllustration;
    public GameObject cloudyIllustration;
    public GameObject rainyIllustration;
    public GameObject stormyIllustraton;

    private void Start()
    {
        EventHandlerScript.current.onCloseExtendedPanel += ClosePanel;
    }
    public void SetDayAndPrecipitation(int day, int precipitation)
    {
        GameObject dayText = this.transform.Find("TextDay").gameObject;
        GameObject precipitationText = this.transform.Find("TextPrecipitationValue").gameObject;

        dayText.GetComponent<TMP_Text>().text = "Day " + day;
        precipitationText.GetComponent<TMP_Text>().text = precipitation + " mm";

        activeDay = day;

        if (precipitation >= 0 && precipitation < 40)
        {
            weatherIllustration = Instantiate(sunnyIllustration, this.transform);
        }
        if (precipitation >= 40 && precipitation < 100)
        {
            weatherIllustration = Instantiate(cloudyIllustration, this.transform);
        }
        if (precipitation >= 100 && precipitation < 150)
        {
            weatherIllustration = Instantiate(rainyIllustration, this.transform);
        }
        if (precipitation >= 150)
        {
            weatherIllustration = Instantiate(stormyIllustraton, this.transform);
        }

        weatherIllustration.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
        weatherIllustration.GetComponent<AnimationController>().StartAnimation();
    }

    private void ClosePanel()
    {
        DeleteWeatherIllustration();
        gameObject.SetActive(false);
    }

    public void DeleteWeatherIllustration()
    {
        Destroy(weatherIllustration);
    }
}
