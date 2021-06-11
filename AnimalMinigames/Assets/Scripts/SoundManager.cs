using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager ui = null;
    public static AudioSource myAudioSource;
    public AudioClip clipTouch;
    public AudioClip clipPop;

    void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        ui = this;
    }
    public void PlayTouchSound()
    {
        Debug.Log("PlayTouchSound");
        myAudioSource.PlayOneShot(clipTouch);
    }
    public void PlayPopSound()
    {
        myAudioSource.PlayOneShot(clipPop);
    }
}
