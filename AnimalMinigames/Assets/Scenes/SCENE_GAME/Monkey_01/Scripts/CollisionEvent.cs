﻿using System.Collections;
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
            switch (collision.tag) {
                case "Coin":
                    // 획득 사운드 재생
                    audioSource.PlayOneShot(soundPoint);
                    GameSystem_Monkey_01.Score += Random.Range(100, 200);
                    textUI.text = StringUtil.NumberFormat(GameSystem_Monkey_01.Score);
                    collision.gameObject.SetActive(false);
                    break;
                case "Item":
                    PlayerMovement.playerBoostTime = 3.0f;
                    collision.gameObject.SetActive(false);
                    break;
                case "Obstacle":
                    PlayerMovement.playerDamagedTime = 0.3f;
                    collision.gameObject.SetActive(false);
                    break;
            }
        }
    }
}
