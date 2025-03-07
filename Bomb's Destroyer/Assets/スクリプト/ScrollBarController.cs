using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollBarController : MonoBehaviour
{
    public Slider scrollbar_power;  // Scrollbarの参照
    public Slider scrollbar_delay;
    private float scrollValue_power = 5;  
    private float scrollValue_Delay = 0; 
    public BombController Bomb;
    public TextMeshProUGUI P_Text;  
    public TextMeshProUGUI D_Text;


    void Start()
    {
        // 初期値を代入
        scrollbar_power.value = scrollValue_power;
        scrollbar_delay.value = scrollValue_Delay;
        
        // Scrollbarの値が変わるたびにメソッドを呼び出す
        scrollbar_power.onValueChanged.AddListener(UpdateValue_power);

        scrollbar_delay.onValueChanged.AddListener(UpdateValue_delay);
    }


        // 値が変更されたときに呼び出される
    void UpdateValue_power(float P_value)
    {
        scrollValue_power = P_value;
        P_Text.text = "威力:" + P_value.ToString();
        switch(P_value)
        {
            case 0: 
            Bomb.explosionForce = 0;
            break;
            case 1:
            Bomb.explosionForce = 2000;
            break;
            case 2:
            Bomb.explosionForce = 4000;
            break;
            case 3:
            Bomb.explosionForce = 6000;
            break; 
            case 4:
            Bomb.explosionForce = 8000;
            break;
            case 5:
            Bomb.explosionForce = 10000;
            break;
            case 6:
            Bomb.explosionForce = 12000;
            break;
            case 7:
            Bomb.explosionForce = 14000;
            break;
            case 8:
            Bomb.explosionForce = 16000;
            break;
            case 9:
            Bomb.explosionForce = 18000;
            break;
            case 10:
            Bomb.explosionForce = 20000;
            break;
        }
        Debug.Log("スクロールバーの値: " + scrollValue_power);
    }

    // 値が変更されたときに呼び出される
    void UpdateValue_delay(float D_value)
    {
        scrollValue_Delay = D_value;
        Bomb.explosionDelay = D_value;
        D_Text.text = "爆発の遅延:" + D_value.ToString();
        Debug.Log("スクロールバーの値: " + scrollValue_Delay);
    }
}
