using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Text;
using System;

public class NextScene : MonoBehaviour, IPointerClickHandler
{
    int ImplemetedLevel = 3;

    StringBuilder current;
    int lastIndex;
    int currentNumber;

    public void OnPointerClick(PointerEventData eventData)
    {
        Cell.ClearSelect();
        Cell.target = null;

        StopAllCoroutines();

        DOTween.Clear(true);

        print(Next());

        SceneManager.LoadScene(Next());
    }

    public string Next()
    {
        current = new StringBuilder(SceneManager.GetActiveScene().name);
        lastIndex = current.Length - 1;
        currentNumber = (int) char.GetNumericValue(current[lastIndex]);

        if (currentNumber > ImplemetedLevel - 1)
            return current.Remove(lastIndex, 1).Insert(lastIndex, 1).ToString();
        else
            return current.Remove(lastIndex, 1).Insert(lastIndex, currentNumber + 1).ToString();
    }
}
