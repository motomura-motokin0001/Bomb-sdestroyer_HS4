using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button[] buttons; // 無効化するボタンの配列

    public void OnButtonClick()
    {
        Debug.Log("ボタンの無効化を開始");
        // ボタンを無効化
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }

    public void ResetButtons()
    {
        Debug.Log("ボタンの無効化を解除");
        // ボタンを再度有効化
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }
}
