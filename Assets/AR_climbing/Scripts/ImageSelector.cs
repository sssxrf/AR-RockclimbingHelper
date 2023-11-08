using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSelector : MonoBehaviour
{
    public Image Image_holder;
    public Sprite orangeMap;
    public Sprite yellowMap;
    public Sprite greenMap;
    // Reference to the script where you get the string from
    public IndicatorManager stringSource;

    private GameObject VoiceControl;
  

    void Start()
    {
        UpdateImage(stringSource.MapImage);
        
    }


    public void SpeechCheck(string SpeechContent)
    {
        
        
        if (SpeechContent == "Show map")
        {

            ShowMap();

        }
        else if (SpeechContent == "Hide map")
        {
            HideMap();
        }
        
    }

    private void UpdateImage(string imageName)
    {
        switch (imageName)
        {
            case "OrangeMap":
                Image_holder.sprite = orangeMap;
                break;
            case "YellowMap":
                Image_holder.sprite = yellowMap;
                break;
            case "GreenMap":
                Image_holder.sprite = greenMap;
                break;
            default:
                Image_holder.sprite = yellowMap;
                break;
        }
    }

    

    void Update()
    {
        UpdateImage(stringSource.MapImage);

    }

    public void ShowMap()
    {
        Image_holder.gameObject.SetActive(true);

    }

    public void HideMap()
    {
        Image_holder.gameObject.SetActive(false);

    }
}
