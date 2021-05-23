using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] Canvas screen;

    [SerializeField] TMP_Text message;

    [SerializeField] GameObject nextButton;

    [SerializeField] Ads ads;

    public void Win()
    {
        ads.ShowRewardedVideo();
        screen.enabled = true;
        message.text = "������";
        nextButton.SetActive(true);
    }

    public void Lose()
    {
        ads.ShowRewardedVideo();
        screen.enabled = true;
        message.text = "���������";
        nextButton.SetActive(false);
    }
}
