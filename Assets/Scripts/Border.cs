using UnityEngine;
using DG.Tweening;

public class Border : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.DOBlendableLocalRotateBy(new Vector3(0, 0, -360), 25f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);

        transform.DOShakeScale(1.5f, new Vector3(0.03f, 0.03f, 0), vibrato: 1).SetLoops(-1);
    }

    private void OnDestroy()
    {
        
    }
}
