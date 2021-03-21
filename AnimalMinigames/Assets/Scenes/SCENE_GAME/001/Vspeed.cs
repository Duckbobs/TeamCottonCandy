using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vspeed : MonoBehaviour
{
    public float jumpSpeed = 0.03f;
    public float gravity = 0.0003f;
    float groundY = 0;
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
        if(groundY == 0) {
            groundY = gameObject.transform.position.y;
        }
        if (gameObject.transform.position.y <= groundY)
        {
            if (vspeed < 0)
            {
                isJump = false;
                vspeed = 0;
                GetComponent<Transform>().transform.position = new Vector3(
                    gameObject.transform.position.x, groundY, gameObject.transform.position.z);
            }
        }
        else
        {
            vspeed -= gravity;
        }
        GetComponent<Transform>().transform.position = new Vector3(
            gameObject.transform.position.x, gameObject.transform.position.y + vspeed, gameObject.transform.position.z);
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
}
