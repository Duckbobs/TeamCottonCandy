using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneChanger
{
    public static void Load(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
    public static void Load_Async(string scene_name)
    {
        // TODO 비동기로 씬 로드 (+로딩 씬 표시)
        SceneManager.LoadScene(scene_name);
    }
}
