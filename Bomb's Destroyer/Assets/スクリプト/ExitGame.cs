using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void InputgetkydownEsc()
    {
        // Escapeキーが押された場合
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // エディタで実行中の場合は停止
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            // ビルドされたゲームの場合はアプリケーションを終了
            Application.Quit();
            #endif
        }
    }
}
