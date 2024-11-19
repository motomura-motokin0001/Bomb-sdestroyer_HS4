using System;
using UnityEngine;

public class ButtonInteract : MonoBehaviour, IInteractable
{
    public GameObject[] prefabsToReset; // リセットしたいプレハブの配列
    public GameObject[] destroyPrefabs;
    public float Xposition = 0;
    public float Yposition = 0;
    public float Zposition = 0;
    private bool isPressed = false; // ボタンが押されたかどうかのフラグ
    private Animator buttonAnimator; // Animatorコンポーネントを参照
    public Action methodName;


    void Start()
    {
        // ボタンのAnimatorを取得
        buttonAnimator = GetComponent<Animator>();
    }

    // インタラクト時の処理
    public void Interact()
    {
        // ボタンが押されていない場合のみ、押す処理を行う
        if (!isPressed)
        {
            PressButton();
        }
    }

    // ボタンを押す処理
    void PressButton()
    {
        Debug.Log("ボタンが押されました。");
        isPressed = true; // ボタンが押されたことを記録
        buttonAnimator.SetTrigger("Press"); // アニメーションを再生するトリガーを設定
        Reset();

        // アニメーションの完了を待ってからボタンの状態をリセット
        StartCoroutine(ResetButtonState());
    }

    private System.Collections.IEnumerator ResetButtonState()
    {
        // アニメーションの長さを取得する（必要に応じて調整）
        yield return new WaitForSeconds(1f); // アニメーションの長さに応じて調整

        // ボタンが再び押せるようにする
        isPressed = false;
    }


    void Reset()
    {
            // 全てのプレハブを削除
            foreach (GameObject prefab in prefabsToReset)
            {
                GameObject[] existingPrefabs = GameObject.FindGameObjectsWithTag(prefab.tag);
                foreach (GameObject obj in existingPrefabs)
                {
                Destroy(obj);
                }
                
            // 同じ位置に再配置
            Vector3 spawnPosition = new Vector3(Xposition, Yposition, Zposition); // ここに再配置したい位置を設定する
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(prefab, spawnPosition, spawnRotation);
            }


        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("destroyObject");
        // 該当オブジェクトが存在するか確認
        if (objectsToDestroy.Length > 0)
        {
            // すべての該当オブジェクトを破壊
            foreach (GameObject obj in objectsToDestroy)
            {
                Destroy(obj);
            }
        }
        else
        {
            // すべてのオブジェクトが破壊された場合、処理を終了
            Debug.Log("All objects with 'destroyObject' tag have been destroyed.");
        }
    }
}


