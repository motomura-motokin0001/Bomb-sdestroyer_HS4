using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void EXIT()
    {
        PlayerPrefs.DeleteKey("PlayerPosX");
        PlayerPrefs.DeleteKey("PlayerPosY");
        PlayerPrefs.DeleteKey("PlayerPosZ");
        PlayerPrefs.Save();
        Debug.Log("<color=green>ゲームを終了します。</color>");
         // エディタで実行中の場合は停止
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
            #else
            // ビルドされたゲームの場合はアプリケーションを終了
            Application.Quit();
            #endif
    }
}
