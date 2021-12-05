using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public static bool isPause = false;
    public GameObject pauseMenu;

    public void DoPause()
    {
        isPause = !isPause;
        pauseMenu.SetActive(isPause);
    }
}
