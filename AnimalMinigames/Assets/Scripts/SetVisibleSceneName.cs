using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetVisibleSceneName : MonoBehaviour
{
    public string[] visibleSceneName;

    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        ////////////////////////////////////////////////////////
        // 보여질 수 있는 씬이면 보이게, 아니라면 안보이게 설정
        bool Active = false;
        foreach (string name in visibleSceneName)
        {
            if (scene.name.Equals(name))
            {
                Active = true;
            }
        }
        gameObject.SetActive(Active);
        ////////////////////////////////////////////////////////
    }

    void OnDisable()
    {
        //SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
