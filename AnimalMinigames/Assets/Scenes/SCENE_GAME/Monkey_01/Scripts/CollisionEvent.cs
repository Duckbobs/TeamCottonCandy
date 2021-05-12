using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionEvent : MonoBehaviour
{
    public AudioClip soundPoint;
    public AudioSource audioSource;
    public bool isPlayer = false;
    public Text textUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayer)
        {
            if (collision.tag == "Object")
            {
                // 획득 사운드 재생
                audioSource.PlayOneShot(soundPoint);
                GameSystem_Monkey_01.Score += Random.Range(100, 200);
                textUI.text = StringUtil.NumberFormat(GameSystem_Monkey_01.Score);
            }
            else if (collision.tag == "Item")
            {
                PlayerMovement.playerBoostTime = 3.0f;
            }
            collision.gameObject.SetActive(false);
        }
    }
}
