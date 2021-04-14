using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public string sceneName;
    private void OnMouseDown()
    {
        SceneChanger.Load_Async(sceneName);
    }
}
