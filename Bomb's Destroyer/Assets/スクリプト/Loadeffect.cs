using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIを扱うための名前空間
using DG.Tweening;

public class Loadeffect : MonoBehaviour
{
    [SerializeField] private Image TargetImage_I; // UnityEngine.UI.Imageを使用

    void Start()
    {
        LOAD();
    }

    public void LOAD()
    {
        Sequence sequence = DOTween.Sequence(); 
        sequence.Append(TargetImage_I.DOFillAmount(0.4f,0.6f).SetEase(Ease.InQuart));
        sequence.Append(TargetImage_I.DOFillAmount(0.7f, 0.6f).SetEase(Ease.InQuart));
        sequence.Append(TargetImage_I.DOFillAmount(1f, 0.8f).SetEase(Ease.InQuart));
    }
}
