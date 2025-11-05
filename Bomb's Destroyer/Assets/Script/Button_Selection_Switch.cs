using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Selection_Switch : MonoBehaviour
{
    [SerializeField] private Button _Default_Button;
    [SerializeField] private Button _Close_Button;
    [SerializeField] private Button _Title_Representative_Button;
    [SerializeField] private Button _Select_Representative_Button;
    [SerializeField] private List<Button> _TitleButtons;
    [SerializeField] private List<Button> _SelectButtons;

    void Start()
    {
        //ONClickイベントに関数を登録
        _Default_Button.onClick.AddListener(OnClickFreePlayButton);
        _Close_Button.onClick.AddListener(OnClickReturnButton);

        foreach (var button in _TitleButtons)
        {
            button.interactable = true;
        }
        
        foreach (var button in _SelectButtons)
        {
            button.interactable = false;
        }
    }


    public void OnClickFreePlayButton()
    {
        foreach (var button in _SelectButtons)
        {
            button.interactable = true;
        }

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_Select_Representative_Button.gameObject);

        foreach (var button in _TitleButtons)
        {
            button.interactable = false;
        }
    }

    public void OnClickReturnButton()
    {
        foreach (var button in _TitleButtons)
        {
            button.interactable = true;
        }

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_Title_Representative_Button.gameObject);

        foreach (var button in _SelectButtons)
        {
            button.interactable = false;
        }
        

    }
    

}