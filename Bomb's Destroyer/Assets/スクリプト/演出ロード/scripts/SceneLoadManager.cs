using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public string DestroySceneName;
    public string SceneLoadName;
    public string EffectSceneName = "effectcanvas";
    private float StockTime = 2f;
    public void SceneLoad()
    {
        
        SceneManager.LoadScene(EffectSceneName,LoadSceneMode.Additive);//||ここでエフェクトシーンを読み込む
        
        StartCoroutine(IE());
    }

    IEnumerator IE()
    {
        Debug.Log("IE");
        Time.timeScale = 1;
        yield return new WaitForSeconds(StockTime);
        SceneManager.UnloadSceneAsync(DestroySceneName);
        SceneManager.LoadScene(SceneLoadName,LoadSceneMode.Additive);  //||ここで次のシーンを読み込む
        
        Debug.Log("complete!!");
    }
}
