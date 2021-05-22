using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Background : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Vector2 startPos;

    public void Awake()
    {
        DOTween.timeScale = 1;
        Time.timeScale = 1;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (startPos == eventData.position)
        {
            Cell.ClearSelect();
            Cell.target = null;
        }
    }

    private void ToAim()
    {
        if (Input.touchCount > 0 && Cell.OnSelect.Count > 0)
        {
            Vector2 endPos = Input.GetTouch(0).position + Input.GetTouch(0).deltaPosition;

            Cell.OnSelect.ForEach(Cell => Cell.LineToAim(endPos));
        }
    }

    public void Update()
    {
        ToAim();

        if (Input.anyKeyDown && Cell.OnSelect.Count > 0)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);

            Cell.OnSelect.ForEach(Cell => Cell.LineToAim(mousePos));

            print(Input.mousePosition);

            print(mousePos);
        }
    }


}
