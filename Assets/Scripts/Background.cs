using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Vector2 startPos;

    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (startPos == eventData.position)
        {
            ClearSelect();
        }
    }

    public void ClearSelect()
    {
        if (Cell.OnSelect.Count > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;

            Cell.OnSelect.ForEach(Cell => Cell.Unselect());
            Cell.OnSelect.Clear();
        }
    }

}
