using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAreaEffect : MonoBehaviour
{
    public AudioSource wrongAreaSoundSource; // Reference to the AudioSource component
    public AudioClip wrongAreaSoundClip; // Sound to play when animal is placed in the wrong area

    public void PlayWrongAreaSound()
    {
        wrongAreaSoundSource.PlayOneShot(wrongAreaSoundClip);
    }
}

