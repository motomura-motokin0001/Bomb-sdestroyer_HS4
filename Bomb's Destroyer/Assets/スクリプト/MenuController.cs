using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    public RectTransform menuPanel;
    public List<Button> menuButton;
    public List<Button> otherButtons;  // 他のボタンのリストを追加

    private bool isMenuVisible = false;
    public Vector3 hiddenPosition;
    public Vector3 visiblePosition;
    public float AT = 1.0f;
    public bool CanTime = true;
    public GameObject MainMene;
    public bool isMenu = true;


    void Start()
    {

        // メニューを隠れた位置に設定
        menuPanel.anchoredPosition = hiddenPosition;

        // ボタンにクリックイベントを登録
        foreach (Button button in menuButton)
        {
            button.onClick.AddListener(ToggleMenu);
        }

        // 他のボタンにクリックイベントを登録
        foreach (Button button in otherButtons)
        {
            button.onClick.AddListener(HideMenu);
        }
    }

    void ToggleMenu()
    {

        if (isMenuVisible)
        {

            // メニューを隠す
            menuPanel.DOAnchorPos(hiddenPosition, AT).SetUpdate(true);


        }
        else
        {
            // メニューを表示
            menuPanel.DOAnchorPos(visiblePosition, AT).SetUpdate(true);

        }
        isMenuVisible = !isMenuVisible;
    }

    void HideMenu()
    {
        if (isMenuVisible)
        {
            // メニューを隠す
            menuPanel.DOAnchorPos(hiddenPosition, 0.5f);
            isMenuVisible = false;
        }
    }

    void Update()
    {
        if (MainMene.activeSelf == false && isMenu == true)
        {
            menuPanel.anchoredPosition = hiddenPosition;
        }
        else
        {
            return;
        }
    }
    
    

}

