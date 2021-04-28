using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private Image ProgressBar;

    public static void Load(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    private IEnumerator Load_Async_Internal(string scene_name)
    {
        ProgressBar.fillAmount = 0.0f;
        var ao = SceneManager.LoadSceneAsync(scene_name);
        ao.allowSceneActivation = false;
        var timer = -0.5f;
        while (!ao.isDone)
        {
            yield return null;
            timer += Time.unscaledDeltaTime;
            if (ao.progress < 0.9f)
            {
                ProgressBar.fillAmount = Mathf.Lerp(ProgressBar.fillAmount, ao.progress, timer);
                if (ProgressBar.fillAmount >= ao.progress) 
                    timer = 0.0f;
            }
            else
            {
                ProgressBar.fillAmount = Mathf.Lerp(ProgressBar.fillAmount, 1.0f, timer);
                if (ProgressBar.fillAmount == 1.0f)
                    ao.allowSceneActivation = true;
            }
        }
    }

    public static void Load_Async(string scene_name)
    {
        var sceneChanger = FindObjectOfType<SceneChanger>();
        if (sceneChanger == null)
        {
            var SceneChangerPrefab = Resources.Load<SceneChanger>("SceneChanger");
            sceneChanger = Instantiate(SceneChangerPrefab);
        }
        sceneChanger.StartCoroutine(sceneChanger.Load_Async_Internal(scene_name));
    }
}
