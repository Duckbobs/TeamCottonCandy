using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager ui = null;
    public AudioSource audio;
    public AudioClip clipTouch;
    public AudioClip clipPop;

    public void Start()
    {
        ui = this;
    }
    public void PlayTouchSound()
    {
        Debug.Log("PlayTouchSound");
        audio.PlayOneShot(clipTouch);
    }
    public void PlayPopSound()
    {
        audio.PlayOneShot(clipPop);
    }
}
