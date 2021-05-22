using UnityEngine;
using UnityEngine.EventSystems;

public class InGameMenu : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject MenuIcon;

    [SerializeField] Canvas Menu;

    public static int layersPlay;

    public void Awake()
    {
        Menu.enabled = false;

        layersPlay = 1 << LayerMask.NameToLayer("Default") | 1 << LayerMask.NameToLayer("Background");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Time.timeScale = 0;
        Menu.enabled = true;

        Camera.main.GetComponent<Physics2DRaycaster>().eventMask &= ~(layersPlay);

    }
}
