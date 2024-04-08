using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSoundEffect : MonoBehaviour
{
    public AudioSource grabSoundSource; // Reference to the AudioSource component
    public AudioClip grabSoundClip; // Sound to play when an animal is grabbed

    public void PlayGrabSound()
    {
        grabSoundSource.PlayOneShot(grabSoundClip);
    }
}
