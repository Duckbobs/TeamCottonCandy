using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vspeed : MonoBehaviour
{
    public float jumpSpeed = 14f;
    public float gravity = 1f;
    public float groundY;
    public float vspeed = 0;
    public int maxJump = 1;
    int isJump = 0;

    public AudioClip soundJump;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        vspeed -= gravity * 70 * Time.deltaTime;
        GetComponent<Transform>().transform.localPosition = new Vector3(
            gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + vspeed * Time.deltaTime, gameObject.transform.localPosition.z);
        if (gameObject.transform.localPosition.y <= groundY)
        {
            if (vspeed < 0)
            {
                isJump = 0;
                vspeed = 0;
                GetComponent<Transform>().transform.localPosition = new Vector3(
                    gameObject.transform.localPosition.x, groundY, gameObject.transform.localPosition.z);
            }
        }
    }

    public void doJump()
    {
        if (isJump < maxJump)
        {
            vspeed = jumpSpeed;
            isJump++;
            if(audioSource != null)
                audioSource.PlayOneShot(soundJump);
        }
    }
    public bool doJump_isJump()
    {
        if (isJump < maxJump)
        {
            vspeed = jumpSpeed;
            isJump++;
            if (audioSource != null)
                audioSource.PlayOneShot(soundJump);
            return true;
        }
        return false;
    }
    public void doUp()
    {
        vspeed = jumpSpeed;
    }

    public bool IsJump()
    {
        return (isJump > 0);
    }
    public int GetJumpCount()
    {
        return isJump;
    }
}
