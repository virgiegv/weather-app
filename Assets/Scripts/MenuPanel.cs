using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MenuPanel : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
    , IPointerClickHandler
{
    public GameObject sunnyIllustration;
    public GameObject cloudyIllustration;
    public GameObject rainyIllustration;
    public GameObject stormyIllustraton;

    private GameObject weatherIllustration;
    
    private int dayNumber;
    private Vector3 sizedUp = new Vector3(1.05f, 1.05f, 1.05f);
    private Vector3 normalSize = new Vector3(1f, 1f, 1f);
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        SizeUpPanel();
        weatherIllustration.GetComponent<AnimationController>().StartAnimation();
    }

    private void SizeUpPanel()
    {
        this.GetComponent<RectTransform>().localScale = sizedUp;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SizeDownPanel();
        weatherIllustration.GetComponent<AnimationController>().StopAnimation();
    }

    public void SizeDownPanel()
    {
        this.GetComponent<RectTransform>().localScale = normalSize;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        EventHandlerScript.current.PanelClicked(dayNumber);
        SizeDownPanel();
        weatherIllustration.GetComponent<AnimationController>().StopAnimation();
    }
    public void SetDayAndPrecipitation(int dayName, int precipitation)
    {
        GameObject dayText = this.transform.Find("TextDay").gameObject;

        dayNumber = dayName;
        dayText.GetComponent<TMP_Text>().text = "Day " + dayName;

        if (precipitation < 40)
        {
            weatherIllustration = Instantiate(sunnyIllustration, this.transform);
        } 
        else if (precipitation >= 40 && precipitation < 100)
        {
            weatherIllustration = Instantiate(cloudyIllustration, this.transform);
        }
        else if (precipitation >= 100 && precipitation < 150)
        {
            weatherIllustration = Instantiate(rainyIllustration, this.transform);
        }
        else if (precipitation >= 150)
        {
            weatherIllustration = Instantiate(stormyIllustraton, this.transform);
        }

    }

}
