using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class SceneEffect : MonoBehaviour
{
    public Image EffectImage;
    public Image load;
    public Image bomb_1;
    public Image bomb_2;

    public string DestroySceneName;

    public void Start()
    {
        var sequence = DOTween.Sequence();

            sequence.Append(EffectImage.DOFade(1f, 0.5f));
            sequence.Append(load.DOFade(0.8f, 0.8f).SetLoops(2, LoopType.Yoyo));

        sequence.AppendInterval(0.3f);


            sequence.Append(EffectImage.DOFade(0f, 0.3f));

            sequence.Join(load.DOFade(0f, 0f));
            sequence.Join(bomb_1.DOFade(0f, 0f));
            sequence.Join(bomb_2.DOFade(0f, 0f)).OnComplete(destroy);

        Debug.Log("完了！");
    }


    void destroy()
    {
        SceneManager.UnloadSceneAsync(DestroySceneName);
        Debug.Log("destroy～");
    }

}
