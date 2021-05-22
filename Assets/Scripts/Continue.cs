using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Continue : MonoBehaviour, IPointerClickHandler
{
    public event Action onClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        Time.timeScale = 1;
        onClick?.Invoke();
    }
}
