using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField]private Animator SelectbuttonAnimator_Right;
    [SerializeField]private Animator SelectbuttonAnimator_Left;
    public Action methodName;
    private const string PosXKey = "PlayerPosX";
    private const string PosYKey = "PlayerPosY";
    private const string PosZKey = "PlayerPosZ";
    public string SceneName_L;
    public string SceneName_R;

    void Start()
    {
        SelectbuttonAnimator_Right = GetComponent<Animator>();        // ボタンのAnimatorを取得
        SelectbuttonAnimator_Left = GetComponent<Animator>();        // ボタンのAnimatorを取得
    }

    // ボタンを押す処理
    public void PressButton_Right()
    {
        Debug.Log("ボタンが押されました。");
        SelectbuttonAnimator_Right.SetTrigger("Select"); // アニメーションを再生するトリガーを設定

        // アニメーションの完了を待ってからボタンの状態をリセット
        StartCoroutine(ResetButtonState());
        savePosition();
        SceneManager.LoadScene(SceneName_L);
    }
    

    public void PressButton_Left()
    {
        Debug.Log("ボタンが押されました。");
        SelectbuttonAnimator_Left.SetTrigger("Select"); // アニメーションを再生するトリガーを設定

        // アニメーションの完了を待ってからボタンの状態をリセット
        StartCoroutine(ResetButtonState());
        savePosition();
        SceneManager.LoadScene(SceneName_L);
    }

    private System.Collections.IEnumerator ResetButtonState()
    {
        // アニメーションの長さを取得する（必要に応じて調整）
        yield return new WaitForSeconds(1f); // アニメーションの長さに応じて調整
    }
    void savePosition()
    {
        Vector3 position = transform.position;
        PlayerPrefs.SetFloat(PosXKey, position.x);
        PlayerPrefs.SetFloat(PosYKey, position.y);
        PlayerPrefs.SetFloat(PosZKey, position.z);
        PlayerPrefs.Save(); // 変更を保存
    }
}