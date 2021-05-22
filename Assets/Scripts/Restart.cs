using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Restart : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Cell.ClearSelect();
        Cell.target = null;

        StopAllCoroutines();

        DOTween.Clear(true);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
