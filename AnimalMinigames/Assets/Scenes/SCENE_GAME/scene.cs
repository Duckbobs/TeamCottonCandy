using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("StageScene");
    }
    public void ChangeSecondScene()
    {
        SceneManager.LoadScene("GameScene_001");
    }
}
