using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpSpeed = 14f;
    public float gravity = 1f;
    public float groundY;
    public float vspeed = 0;
    public int maxJump = 1;
    int isJump = 0;


    public static float playerBoostTime = 0;
    public static float playerSpeed = 0;
    public static float playerDamagedTime = 0;

    public bool modeTwoLines = false;
    float modeTwoLines_groundY = 0;

    public AudioClip soundJump;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        modeTwoLines_groundY = groundY;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBoostTime > 0)
        {
            playerBoostTime -= 1.0f * Time.deltaTime;
            playerSpeed = 20;
        }
        else
        {
            playerSpeed = 1;
        }

        if (playerDamagedTime > 0)
        {
            playerDamagedTime -= 1.0f * Time.deltaTime;
        }

        if (modeTwoLines)
        {
            GetComponent<Transform>().transform.localPosition = new Vector3(gameObject.transform.localPosition.x, Mathf.Lerp(gameObject.transform.localPosition.y, modeTwoLines_groundY, 0.3f), gameObject.transform.localPosition.z);
            vspeed = 0;
        }
        else
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

    }

    public void doJump()
    {

        if (modeTwoLines)
        {
            if (modeTwoLines_groundY == groundY)
            {
                modeTwoLines_groundY = groundY + 1.0f;
            }
            else
            {
                modeTwoLines_groundY = groundY;
            }
        }
        else
        {
            if (isJump < maxJump)
            {
                vspeed = jumpSpeed;
                isJump++;
                if (audioSource != null)
                    audioSource.PlayOneShot(soundJump);
            }
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
