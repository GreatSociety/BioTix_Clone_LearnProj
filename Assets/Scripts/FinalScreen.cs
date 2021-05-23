using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] Canvas screen;

    [SerializeField] TMP_Text message;

    [SerializeField] GameObject nextButton;

    public void Win()
    {
        screen.enabled = true;
        message.text = "Победа";
        nextButton.SetActive(true);
    }

    public void Lose()
    {
        screen.enabled = true;
        message.text = "Поражение";
        nextButton.SetActive(false);
    }
}
