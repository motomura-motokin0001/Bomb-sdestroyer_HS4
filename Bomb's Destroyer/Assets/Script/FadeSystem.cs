using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSystem : MonoBehaviour
{

    public static bool IsFadeOut = false;
    [SerializeField] private Image _fadeImage;
    [SerializeField] private float FadeTime = 1.0f;

    void Start()
    {
        Reset();
    }

    public void FadeIn(string NextSceneName)
    {
        _fadeImage.raycastTarget = true;
        Debug.Log("Fade In");
        _fadeImage.DOFade(1, FadeTime).SetUpdate(true).OnComplete(() =>
        {
            SceneManager.LoadScene(NextSceneName);
        });
    }

    public void ISOut(bool FadeOut)
    {
        IsFadeOut = FadeOut;
    }

    void FadeOut()
    {
        Debug.Log("Fade Out");
        _fadeImage.DOFade(0, FadeTime).SetUpdate(true).OnComplete(() =>
        {
            _fadeImage.raycastTarget = false;
            Reset();
        });
    }

    void Reset()
    {
        switch (IsFadeOut)
        {
            case true:
            {
                _fadeImage.color = new Color(1, 1, 1, 1);
                FadeOut();
                IsFadeOut = false;
                break;
            }
            case false:
            {
                _fadeImage.color = new Color(1, 1, 1, 0);
                _fadeImage.raycastTarget = false;                
                break;
            }
        }

    }
}
