using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections.Generic;

public class ButtonOn : MonoBehaviour
{
    [SerializeField] Button focusButton;

    void Start()
    {
        // ボタンコンポーネントの取得
        focusButton = focusButton.GetComponent<Button>();
    }

    public void OnClick()
    {
        //全てのフォーカスを解除する
        EventSystem.current.SetSelectedGameObject(null);
        //focusButtonにフォーカスする
        focusButton.Select();
        //Canvasコンポーネントを無効にする。Buttonコンポーネントで設定可。
    }
    public void OnPointerEnter()
    {
        this.transform.DOScale(1.2f, 0.2f).SetEase(Ease.OutBack);
        //focusButtonにフォーカスする
        focusButton.Select();
    }
}