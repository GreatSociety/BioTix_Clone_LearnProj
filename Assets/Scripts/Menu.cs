using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Canvas))]
public class Menu : MonoBehaviour
{
    [SerializeField] Continue continueGame;
    [SerializeField] Restart restart;
    [SerializeField] Exit exit;

    Canvas inGameMenu;

    public void Awake()
    {
        inGameMenu = GetComponent<Canvas>();

        continueGame.onClick += ContinueGame;
    }

    private void ContinueGame()
    {
        inGameMenu.enabled = false;

        Camera.main.GetComponent<Physics2DRaycaster>().eventMask |= InGameMenu.layersPlay;
    }
}
