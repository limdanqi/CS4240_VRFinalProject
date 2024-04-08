using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAreaEffect : MonoBehaviour
{
    public AudioSource rightAreaSoundSource; // Reference to the AudioSource component
    public AudioClip rightAreaSoundClip; // Sound to play when animal is placed in the right area

    public void PlayRightAreaSound()
    {
        rightAreaSoundSource.PlayOneShot(rightAreaSoundClip);
    }
}
