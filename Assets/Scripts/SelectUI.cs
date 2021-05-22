using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelectUI : MonoBehaviour
{
    void Start()
    {
        transform.DOScale(transform.localScale.x * 0.8f, 0.6f);
    }
}
