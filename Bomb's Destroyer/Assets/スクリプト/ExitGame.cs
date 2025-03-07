using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Update()
    {
        // Escapeキーが押された場合
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayerPrefs.DeleteKey("PlayerPosX");
            PlayerPrefs.DeleteKey("PlayerPosY");
            PlayerPrefs.DeleteKey("PlayerPosZ");
            PlayerPrefs.Save();
            EXIT();

        }
    }
    public void EXIT()
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
