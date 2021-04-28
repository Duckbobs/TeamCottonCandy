using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionEvent : MonoBehaviour
{
    public AudioClip soundPoint;
    public AudioSource bgmAudioSource;
    public bool isPlayer = false;
    public Text textUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Object")
        {
            Destroy(collision.gameObject);
            if (isPlayer)
            {
                // 획득 사운드 재생
                bgmAudioSource.PlayOneShot(soundPoint);
                GameSystem_Monkey_01.Score += Random.Range(100, 200);
                textUI.text = StringUtil.NumberFormat(GameSystem_Monkey_01.Score);
            }
        }
    }
}
