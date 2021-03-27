﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vspeed : MonoBehaviour
{
    public float jumpSpeed = 0.03f;
    public float gravity = 0.0003f;
    public float groundY;
    float vspeed = 0;
    bool isJump = false;

    public AudioClip soundJump;
    public AudioSource bgmAudioSource;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localPosition.y <= groundY)
        {
            if (vspeed < 0)
            {
                isJump = false;
                vspeed = 0;
                GetComponent<Transform>().transform.localPosition = new Vector3(
                    gameObject.transform.localPosition.x, groundY, gameObject.transform.localPosition.z);
            }
        }
        else
        {
            vspeed -= gravity;
        }
        GetComponent<Transform>().transform.localPosition = new Vector3(
            gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + vspeed * Time.deltaTime, gameObject.transform.localPosition.z);
    }

    public void doJump()
    {
        if (isJump == false)
        {
            vspeed = jumpSpeed;
            isJump = true;
            bgmAudioSource.PlayOneShot(soundJump);
        }
    }
    public void doUp()
    {
        vspeed = jumpSpeed;
    }
}