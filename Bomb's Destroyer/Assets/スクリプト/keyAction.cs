using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyAction : MonoBehaviour
{
    public GameObject PauseOJ;
    private bool isMenuVisible = false;
    public BombThrower bombThrower;

    void Start()
    {
        PauseOJ.SetActive(false);
        Time.timeScale = 1; // ゲーム開始時は通常速度
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuVisible = !isMenuVisible;
            bombThrower.canThrowBomb = !isMenuVisible;

            // ゲームの一時停止 or 再開
            Time.timeScale = isMenuVisible ? 0 : 1;

            // メニューの表示・非表示
            PauseOJ.SetActive(isMenuVisible);

            Debug.Log("Escが押されました");
        }
    }

    public void OnClickResumeButton()
    {
        isMenuVisible = false;
        bombThrower.canThrowBomb = true;

        // ゲームの再開
        Time.timeScale = 1;


        // メニューの非表示
        PauseOJ.SetActive(false);
    }
}
