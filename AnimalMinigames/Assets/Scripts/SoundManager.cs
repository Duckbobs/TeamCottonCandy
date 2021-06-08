using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager ui;
    public AudioSource audio;
    public AudioClip clip;

    public void Start()
    {
        ui = this;
    }
    public void PlayTouchSound()
    {
        audio.PlayOneShot(clip);
    }
}
